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
            string homeImageUrl = "";
            if (productViewModel != null)
            {
                foreach (var image in productViewModel.Images)
                {
                    homeImageUrl = image.FileName;
                    if (homeImageUrl.Contains("Home"))
                    {
                        homeImageUrl = UploadFiles(image);
                        break;
                    }
                }
            }
            productViewModel.Products.HomeImgUrl = homeImageUrl;
            await _context.AddAsync(productViewModel.Products);
            await _context.SaveChangesAsync();
            var NewProduct = await _context.Products.Include(u => u.Category).FirstOrDefaultAsync(u => u.Name == productViewModel.Products.Name);
            productViewModel.Inventories.Name = NewProduct.Name;
            productViewModel.Inventories.Category = NewProduct.Category.Name;
            await _context.inventories.AddAsync(productViewModel.Inventories);
            await _context.SaveChangesAsync();

            if (productViewModel.Images != null)
            {
                foreach (var image in productViewModel.Images)
                {
                    string tempFileName = image.FileName;
                    if (!tempFileName.Contains("Home"))
                    {
                        string stringFileName = UploadFiles(image);
                        var addressImage = new PImages
                        {
                            ImageUrl = stringFileName,
                            ProductId = NewProduct.Id,
                            ProductName = NewProduct.Name,
                        };
                        await _context.PImages.AddAsync(addressImage);
                    }
                }
            }
            await _context.SaveChangesAsync();

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
            var ProductToEdit = await _context.Products.FirstOrDefaultAsync(u => u.Id == productViewModel.Products.Id);

            if (ProductToEdit != null)
            {
                // Update product properties
                ProductToEdit.Name = productViewModel.Products.Name;
                ProductToEdit.Price = productViewModel.Products.Price;
                ProductToEdit.Description = productViewModel.Products.Description;
                ProductToEdit.CategoryId = productViewModel.Products.CategoryId;

                // Handle Image Uploads
                if (productViewModel.Images != null)
                {
                    foreach (var item in productViewModel.Images)
                    {
                        string tempFileName = item.FileName;
                        if (!tempFileName.Contains("Home"))
                        {
                            string stringFileName = UploadFiles(item);
                            var addressImage = new PImages
                            {
                                ImageUrl = stringFileName,
                                ProductId = productViewModel.Products.Id,
                                ProductName = productViewModel.Products.Name,
                            };
                            await _context.PImages.AddAsync(addressImage);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(ProductToEdit.HomeImgUrl))
                            {
                                string homeImageUrl = UploadFiles(item);
                                ProductToEdit.HomeImgUrl = homeImageUrl;
                            }
                        }
                    }
                }

                // Ensure update to the product entity
                _context.Products.Update(ProductToEdit);

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

            // Remove the image from the database
            _context.PImages.Remove(image);
            await _context.SaveChangesAsync();

            string imageUrl = Path.Combine(_HostEnvironment.WebRootPath, "Images", image.ImageUrl);
            DeleteImage(imageUrl);


            // Fetch the updated product details after image deletion
            var product = await _context.Products
                .Include(p => p.ImgUrls) // Ensure related images are included
                .FirstOrDefaultAsync(p => p.Id == image.ProductId);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Prepare the view model for the Edit view
            var viewModel = new ProductViewModel
            {
                Products = product,
                CategoriesList = await _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToListAsync() // Convert to SelectListItems for dropdown
            };

            // Return the Edit view with the updated product data
            return View("Edit", viewModel);
        }


    }
}
