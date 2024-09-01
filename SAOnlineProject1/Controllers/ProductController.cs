using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SAOnlineProject1.Data;
using SAOnlineProject1.Models;

namespace SAOnlineProject1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _HostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _HostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Include(u => u.Category).ToList();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Inventories = new Inventory(),
                PImages = new PImages(),
                CategoriesList = _context.Categories.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
            };
            return View(productViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            // Create a new product instance
            var newProduct = new Product
            {
                Name = productViewModel.Products.Name,
                Price = productViewModel.Products.Price,
                Description = productViewModel.Products.Description,
                CategoryId = productViewModel.Products.CategoryId
            };

            // Add the new product to the context
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            // Handle Image Uploads
            if (productViewModel.Images != null && productViewModel.Images.Any())
            {
                foreach (var item in productViewModel.Images)
                {
                    string stringFileName = UploadFiles(item);

                    var addressImage = new PImages
                    {
                        ImageUrl = stringFileName,
                        ProductId = newProduct.Id,  // Associate the image with the newly created product
                        ProductName = newProduct.Name,
                    };

                    await _context.PImages.AddAsync(addressImage);

                    // Update the HomeImgUrl if it's a Home image or if HomeImgUrl is empty
                    if (item.FileName.Contains("Home") || string.IsNullOrEmpty(newProduct.HomeImgUrl))
                    {
                        newProduct.HomeImgUrl = stringFileName;
                    }
                }

                // Update the new product's HomeImgUrl in the database
                _context.Products.Update(newProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Product");
        }


        private string UploadFiles(IFormFile image)
        {
            string fileName = null;
            if (image != null)
            {
                string uploadDirLocation = Path.Combine(_HostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadDirLocation, fileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(filestream);
                }
            }
            return fileName;

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            // Retrieve the product to edit
            var productToEdit = _context.Products.FirstOrDefault(p => p.Id == Id);

            if (productToEdit == null)
            {
                // Handle the case when the product is not found
                return NotFound(); // You might want to return a custom "Not Found" view
            }

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Products = productToEdit, // Initialize with the found product
                CategoriesList = _context.Categories.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                // Initialize ImgUrls
                ImgUrls = _context.PImages.Where(u => u.ProductId == Id).ToList()
            };

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            var productToEdit = await _context.Products.FirstOrDefaultAsync(u => u.Id == productViewModel.Products.Id);

            if (productToEdit != null)
            {
                // Update product properties
                productToEdit.Name = productViewModel.Products.Name;
                productToEdit.Price = productViewModel.Products.Price;
                productToEdit.Description = productViewModel.Products.Description;
                productToEdit.CategoryId = productViewModel.Products.CategoryId;

                // Handle Image Uploads
                if (productViewModel.Images != null)
                {
                    foreach (var item in productViewModel.Images)
                    {
                        string tempFileName = item.FileName;

                        // Upload the image
                        string stringFileName = UploadFiles(item);

                        var addressImage = new PImages
                        {
                            ImageUrl = stringFileName,
                            ProductId = productViewModel.Products.Id,
                            ProductName = productViewModel.Products.Name,
                        };

                        await _context.PImages.AddAsync(addressImage);

                        // Update HomeImgUrl if it's a Home image or if HomeImgUrl is empty
                        if (tempFileName.Contains("Home") || string.IsNullOrEmpty(productToEdit.HomeImgUrl))
                        {
                            productToEdit.HomeImgUrl = stringFileName;
                        }
                    }
                }

                // Ensure update to the product entity
                _context.Products.Update(productToEdit);

                // Save changes asynchronously
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Product");
        }



        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var productToDelete = _context.Products.FirstOrDefault(c => c.Id == Id);
            var ImagesToDelete = _context.PImages.Where(up => up.ProductId == Id).Select(up => up.ImageUrl).ToList();
            foreach (var image in ImagesToDelete)
            {
                string imageUrl = "Images\\" + image;
                var toDeleteImageFromFolder = Path.Combine(_HostEnvironment.WebRootPath, imageUrl.TrimStart('\\'));
                DeleteImage(toDeleteImageFromFolder);
            }

            if (productToDelete.HomeImgUrl != "")
            {
                string imageUrl = "Images\\" + productToDelete.HomeImgUrl;
                var toDeleteImageFromFolder = Path.Combine(_HostEnvironment.WebRootPath, imageUrl.TrimStart('\\'));
                DeleteImage(toDeleteImageFromFolder);
            }

            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        private void DeleteImage(string toDeleteImageFromFolder)
        {
            if (System.IO.File.Exists(toDeleteImageFromFolder))
            {
                System.IO.File.Delete(toDeleteImageFromFolder);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImg(string id)
        {
            // Validate the incoming image ID
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Image ID cannot be null or empty.");
            }

            // Find the image by its ID
            var image = await _context.PImages.FirstOrDefaultAsync(img => img.ImageUrl == id);
            if (image == null)
            {
                return NotFound("Image not found.");
            }

            // Get the product related to the image
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == image.ProductId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Remove the image from the database
            _context.PImages.Remove(image);
            await _context.SaveChangesAsync();

            // Delete the image file from the folder
            string imageUrl = Path.Combine(_HostEnvironment.WebRootPath, "Images", image.ImageUrl);
            DeleteImage(imageUrl);

            // If the deleted image was the HomeImgUrl, update it to another image or clear it
            if (product.HomeImgUrl == image.ImageUrl)
            {
                var newHomeImg = await _context.PImages
                    .Where(img => img.ProductId == product.Id)
                    .OrderByDescending(img => img.Id)
                    .FirstOrDefaultAsync();

                product.HomeImgUrl = newHomeImg?.ImageUrl;
            }

            // Ensure the product entity is updated
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            // Prepare the view model for the Edit view
            var viewModel = new ProductViewModel
            {
                Products = product,
                CategoriesList = await _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToListAsync(),
                ImgUrls = await _context.PImages.Where(img => img.ProductId == product.Id).ToListAsync()
            };

            // Return the Edit view with the updated product data
            return View("Edit", viewModel);
        }




    }
}
