using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineProject1.Data;
using SAOnlineProject1.Models;
using SAOnlineProject1.Utility;


namespace SAOnlineProject1.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CartController(ApplicationDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult CartIndex()
        {
            var claim = _signInManager.IsSignedIn(User); 
            if (claim)
            {
                var userId = _userManager.GetUserId(User);
                CartIndexViewModel cartIndexVM = new CartIndexViewModel()
                {
                    productList = _db.UserCarts.Include(u => u.product).Where(u => u.UserId.Contains(userId)).ToList(),
                };
                var count = _db.UserCarts.Where(u => userId.Contains(userId)).Count();
                HttpContext.Session.SetInt32(cartCount.sessionCount, count);

                return View(cartIndexVM);
            }        
            return View();            
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1, string? returnUrl = null)
        {
            var productAddToCart = await _db.Products.FirstOrDefaultAsync(u => u.Id == productId);
            var isUserSignedIn = _signInManager.IsSignedIn(User);

            if (isUserSignedIn)
            {
                var userId = _userManager.GetUserId(User);
                if (userId != null)
                {
                    // Check if the signed-in user has any cart items
                    var userCartItems = await _db.UserCarts.Where(u => u.UserId == userId).ToListAsync();

                    // Check if the product is already in the cart
                    var existingCartItem = userCartItems.FirstOrDefault(p => p.ProductId == productId);
                    if (existingCartItem != null)
                    {
                        // If the item is already in the cart, update the quantity
                        existingCartItem.Quantity += quantity;
                        _db.UserCarts.Update(existingCartItem);
                    }
                    else
                    {
                        // If the item is not in the cart, add a new cart item
                        UserCart newItemToCart = new UserCart
                        {
                            ProductId = productId,
                            UserId = userId,
                            Quantity = quantity,
                        };
                        await _db.UserCarts.AddAsync(newItemToCart);
                    }

                    // Save changes to the database
                    await _db.SaveChangesAsync();
                }
            }

            // Redirect to the return URL or to the cart index
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("CartIndex", "Cart");
        }



        public IActionResult MinusAnItem(int productId)
        {
            var userId = _userManager.GetUserId(User);
            var itemToMinus = _db.UserCarts.FirstOrDefault(p => p.ProductId == productId && p.UserId == userId);

            if (itemToMinus != null)
            {
                if (itemToMinus.Quantity > 1)
                {                     
                    itemToMinus.Quantity -= 1;
                    _db.UserCarts.Update(itemToMinus);
                }
                else
                {                     
                    _db.UserCarts.Remove(itemToMinus);
                }

                _db.SaveChanges();
            }

            return RedirectToAction(nameof(CartIndex));
        }

        public IActionResult DeleteAnItem(int productId)
        {
            var userId = _userManager.GetUserId(User);
            var itemToDelete = _db.UserCarts.FirstOrDefault(p => p.ProductId == productId && p.UserId == userId);

            if (itemToDelete != null)
            {
                _db.UserCarts.Remove(itemToDelete);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(CartIndex));
        }

    }
}
