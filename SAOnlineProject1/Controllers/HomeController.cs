using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineProject1.Data;
using SAOnlineProject1.Models;
using SAOnlineProject1.Utility;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private const int PageSize = 4;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _db = db;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(string? searchByName, string? searchByCategory, int page = 1)
    {
        if (_signInManager.IsSignedIn(User))
        {
            var userId = _userManager.GetUserId(User);
            var count = await _db.UserCarts.CountAsync(u => u.UserId == userId);
            HttpContext.Session.SetInt32(cartCount.sessionCount, count);
        }

        HomePageViewModel vm = new HomePageViewModel
        {
            Categories = await _db.Categories.ToListAsync(),
            searchByName = searchByName
        };

        IQueryable<Product> productsQuery = _db.Products;

        // Search Logic
        if (!string.IsNullOrEmpty(searchByName))
        {
            productsQuery = productsQuery.Where(product => EF.Functions.Like(product.Name, $"%{searchByName}%"));
        }
        else if (!string.IsNullOrEmpty(searchByCategory))
        {
            var category = await _db.Categories.FirstOrDefaultAsync(u => u.Name == searchByCategory);
            if (category != null)
            {
                productsQuery = productsQuery.Where(u => u.CategoryId == category.Id);
            }
        }

        vm.TotalProducts = await productsQuery.CountAsync();
        vm.TotalPages = (int)Math.Ceiling(vm.TotalProducts / (double)PageSize);
        vm.CurrentPage = page;

        // Retrieve products for the current page
        vm.ProductList = await productsQuery
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        return View(vm);
    }  

}
