using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineProject1.Data;
using SAOnlineProject1.Models;
using SAOnlineProject1.Utility;

namespace SAOnlineProject1.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public OrderController(ApplicationDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult orderDetailPreview()
        {

            var claim = _signInManager.IsSignedIn(User);
            if (claim)
            {
                var userId = _userManager.GetUserId(User);
                var currentUser = _db.applicationUser.FirstOrDefault(x => x.Id == userId);
                SummaryViewModel summaryVM = new SummaryViewModel()
                {
                    userCartList = _db.UserCarts.Include(u => u.product).Where(u => u.userId.Contains(userId)).ToList(),
                    orderSummery = new UserOrderHeader(),
                    cartUserId = userId,
                };
              
                if(currentUser!= null)
                {
                    summaryVM.orderSummery.DeliveryStreetAddress = currentUser.Address;
                    summaryVM.orderSummery.City = currentUser.City;
                    summaryVM.orderSummery.Province = currentUser.Province;
                    summaryVM.orderSummery.PostalCode = currentUser.PostalCode;
                    summaryVM.orderSummery.Name = currentUser.FirstName + " " + currentUser.LastName;
                }
                var count = _db.UserCarts.Where(u => userId.Contains(userId)).Count();
                HttpContext.Session.SetInt32(cartCount.sessionCount, count);

                return View(summaryVM);

            }
            return View();
            
        }
    }
}
