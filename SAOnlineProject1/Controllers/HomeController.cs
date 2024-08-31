using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineProject1.Data;
using SAOnlineProject1.Models;
using SAOnlineProject1.Utility;
using System.Diagnostics;

namespace SAOnlineProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _db = db;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index(string? searchByName, string? searchByCategory)
        {

            var claim = _signInManager.IsSignedIn(User); 
            if (claim)
            {
                var userId = _userManager.GetUserId(User);
                var count = _db.UserCarts.Where(u => userId.Contains(userId)).Count();
                HttpContext.Session.SetInt32(cartCount.sessionCount, count);
            }


            HomePageViewModel vm = new HomePageViewModel();
            vm.Categories = _db.Categories.ToList(); // Always initialize Categories

            vm.searchByName = searchByName;

            if (!string.IsNullOrEmpty(searchByName))
            {
                vm.ProductList = _db.Products
                    .Where(product => EF.Functions.Like(product.Name, $"%{searchByName}%"))
                    .ToList();
            }
            else if (searchByCategory != null)
            {
                var searchByCategoryName = _db.Categories.FirstOrDefault(u => u.Name == searchByCategory);
                if (searchByCategoryName != null) // Check for null to avoid exceptions
                {
                    vm.ProductList = _db.Products
                        .Where(u => u.CategoryId == searchByCategoryName.Id)
                        .ToList();
                }
                else
                {
                    vm.ProductList = new List<Product>(); // Initialize ProductList if category not found
                }
            }
            else
            {
                vm.ProductList = _db.Products.ToList();
            }

            return View(vm);
        }
    }
}
