using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SAOnlineProject1.Data;
using SAOnlineProject1.Models;
using System.Globalization;

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

        [Authorize]
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
            
            var newProduct = new Product
            {
                Name = productViewModel.Products.Name,
                Price = productViewModel.Products.Price,
                Description = productViewModel.Products.Description,
                CategoryId = productViewModel.Products.CategoryId
            };

             
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            
            if (productViewModel.Images != null && productViewModel.Images.Any())
            {
                foreach (var item in productViewModel.Images)
                {
                    string stringFileName = UploadFiles(item);

                    var addressImage = new PImages
                    {
                        ImageUrl = stringFileName,
                        ProductId = newProduct.Id,  
                        ProductName = newProduct.Name,
                    };

                    await _context.PImages.AddAsync(addressImage);

                    
                    if (item.FileName.Contains("Home") || string.IsNullOrEmpty(newProduct.HomeImgUrl))
                    {
                        newProduct.HomeImgUrl = stringFileName;
                    }
                }

                
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
            
            var productToEdit = _context.Products.FirstOrDefault(p => p.Id == Id);

            if (productToEdit == null)
            {
               
                return NotFound();  
            }

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Products = productToEdit,  
                CategoriesList = _context.Categories.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                
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
                
                productToEdit.Name = productViewModel.Products.Name;
                productToEdit.Price = productViewModel.Products.Price;
                productToEdit.Description = productViewModel.Products.Description;
                productToEdit.CategoryId = productViewModel.Products.CategoryId;

               
                if (productViewModel.Images != null)
                {
                    foreach (var item in productViewModel.Images)
                    {
                        string tempFileName = item.FileName;

                       
                        string stringFileName = UploadFiles(item);

                        var addressImage = new PImages
                        {
                            ImageUrl = stringFileName,
                            ProductId = productViewModel.Products.Id,
                            ProductName = productViewModel.Products.Name,
                        };

                        await _context.PImages.AddAsync(addressImage);

                       
                        if (tempFileName.Contains("Home") || string.IsNullOrEmpty(productToEdit.HomeImgUrl))
                        {
                            productToEdit.HomeImgUrl = stringFileName;
                        }
                    }
                }

               
                _context.Products.Update(productToEdit);

                
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
             
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Image ID cannot be null or empty.");
            }

            
            var image = await _context.PImages.FirstOrDefaultAsync(img => img.ImageUrl == id);
            if (image == null)
            {
                return NotFound("Image not found.");
            }

            
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == image.ProductId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

             
            _context.PImages.Remove(image);
            await _context.SaveChangesAsync();

             
            string imageUrl = Path.Combine(_HostEnvironment.WebRootPath, "Images", image.ImageUrl);
            DeleteImage(imageUrl);

            
            if (product.HomeImgUrl == image.ImageUrl)
            {
                var newHomeImg = await _context.PImages
                    .Where(img => img.ProductId == product.Id)
                    .OrderByDescending(img => img.Id)
                    .FirstOrDefaultAsync();

                product.HomeImgUrl = newHomeImg?.ImageUrl;
            }

             
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            
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

             
            return View("Edit", viewModel);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ImgUrls)
                .FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = new ProductViewModel
            {
                Products = product,
                CategoriesList = _context.Categories.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                ImgUrls = _context.PImages.Where(u => u.ProductId == Id).ToList()
            };

            return View(productViewModel);
        }


    }
}
