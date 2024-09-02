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
                     
                    var userCartItems = await _db.UserCarts.Where(u => u.UserId == userId).ToListAsync();

                     
                    var existingCartItem = userCartItems.FirstOrDefault(p => p.ProductId == productId);
                    if (existingCartItem != null)
                    {
                         
                        existingCartItem.Quantity += quantity;
                        _db.UserCarts.Update(existingCartItem);
                    }
                    else
                    {
                       
                        UserCart newItemToCart = new UserCart
                        {
                            ProductId = productId,
                            UserId = userId,
                            Quantity = quantity,
                        };
                        await _db.UserCarts.AddAsync(newItemToCart);
                    }

                     
                    await _db.SaveChangesAsync();
                }
            }

             
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
