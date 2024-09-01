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
                    productList = _db.UserCarts.Include(u => u.product).Where(u => u.userId.Contains(userId)).ToList(),
                };
                var count = _db.UserCarts.Where(u => userId.Contains(userId)).Count();
                HttpContext.Session.SetInt32(cartCount.sessionCount, count);

                return View(cartIndexVM);
            }        
            return View();            
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(int productId, string? returnUrl)
        {
            var productAddToCart = await _db.Products.FirstOrDefaultAsync(u => u.Id == productId);
            var CheckIfUserSignedInOrNot = _signInManager.IsSignedIn(User);
            if (CheckIfUserSignedInOrNot)
            {
                var user = _userManager.GetUserId(User);
                if (user != null)
                {
                    //Check if the signed user has any cart or not?
                    var getTheCartIfAnyExistForTheUser = await _db.UserCarts.Where(u => u.userId.Contains(user)).ToListAsync();
                    if (getTheCartIfAnyExistForTheUser.Count() > 0)
                    {
                        //check if the item is already in the cart or not
                        var getTheQuantity = getTheCartIfAnyExistForTheUser.FirstOrDefault(p => p.ProductId == productId);
                        if (getTheQuantity != null)
                        {//if the item is already in the cart just increase the quantity by 1 and update the cart.
                            getTheQuantity.Quantity = getTheQuantity.Quantity + 1;
                            _db.UserCarts.Update(getTheQuantity);
                        }
                        else
                        { // User has a cart but addding a new item to the existing cart.
                            UserCart newItemToCart = new UserCart
                            {
                                ProductId = productId,
                                userId = user,
                                Quantity = 1,
                            };
                            await _db.UserCarts.AddAsync(newItemToCart);
                        }
                    }
                    else
                    {
                        UserCart newItemToCart = new UserCart
                        {
                            ProductId = productId,
                            userId = user,
                            Quantity = 1,
                        };
                        await _db.UserCarts.AddAsync(newItemToCart);
                    }
                    await _db.SaveChangesAsync();
                }
            }
            if (returnUrl != null)
            {
                return RedirectToAction("CartIndex", "Cart");
            }
            return RedirectToAction("Index","Home");
        }


        public IActionResult MinusAnItem(int productId)
        {
            var itemToMinus = _db.UserCarts.FirstOrDefault(p => p.ProductId == productId);
            if (itemToMinus != null)
            {
                _db.UserCarts.Remove(itemToMinus);

            } 
            else
            {
                itemToMinus.Quantity -= 1;
                _db.UserCarts.Update(itemToMinus);
            }
            _db.SaveChanges();
            
            return RedirectToAction(nameof(CartIndex));
        }

               public IActionResult DeleteAnItem(int productId)
        {
            var itemToMinus = _db.UserCarts.FirstOrDefault(p => p.ProductId == productId);
            if (itemToMinus != null)
            {
                _db.UserCarts.Remove(itemToMinus);         
                _db.UserCarts.Update(itemToMinus);
            }
            _db.SaveChanges();
            
            return RedirectToAction(nameof(CartIndex));
        }


    }
}
