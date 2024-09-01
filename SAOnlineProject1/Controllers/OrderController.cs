using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SAOnlineProject1.Data;
using SAOnlineProject1.Models;
using SAOnlineProject1.Utility;
using System.Collections.Generic;

namespace SAOnlineProject1.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public OrderDetailsModelView OrderDetailsModelView { get; set; }

        public OrderController(ApplicationDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> orderDetailPreview()
        {

            var claim = _signInManager.IsSignedIn(User);
            if (claim)
            {
                var userId = _userManager.GetUserId(User);
                var currentUser = _db.applicationUser.FirstOrDefault(x => x.Id == userId);
                SummaryViewModel summaryVM = new SummaryViewModel()
                {
                    userCartList = _db.UserCarts.Include(u => u.product).Where(u => u.UserId.Contains(userId)).ToList(),
                    orderSummery = new UserOrderHeader(),
                    cartUserId = userId,
                };

                if (currentUser != null)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Summary(SummaryViewModel summeryVMFromView)
        {
            var selectedPaymentOption = summeryVMFromView.SelectedPaymentOption;

            if (!string.IsNullOrEmpty(selectedPaymentOption))
            {

            }
            else
            {
                selectedPaymentOption = "card";
            }


            var claim = _signInManager.IsSignedIn(User);
            if (claim)
            {
                var userId = _userManager.GetUserId(User); // Get the currently logged-in user's ID
                var currentUser = await _db.applicationUser.FindAsync(userId);

                var totalOrderAmount = _db.UserCarts
                 .Include(u => u.product)
                 .Where(u => u.UserId == userId)
                 .Sum(u => u.product.Price * u.Quantity);

                // Initialize a new order summary
                var orderSummery = new UserOrderHeader
                {
                    ApplicationUserId = currentUser.Id,
                    UserId = currentUser.Id,
                    DateOfOrder = DateTime.Now,
                    DeliveryStreetAddress = currentUser.Address,
                    City = currentUser.City,
                    Province = currentUser.Province,
                    PostalCode = currentUser.PostalCode,
                    Name = currentUser.FirstName + " " + currentUser.LastName,
                    DateOfShipped = DateTime.Now.AddDays(7),
                    OrderStatus = "Pending",
                    PaymentStatus = "Not Paid",
                    PaymentProccessDate = DateTime.Now,
                    TransactionId = selectedPaymentOption,
                    TotalOrderAmount = totalOrderAmount,
                };

                await _db.AddAsync(orderSummery); // Add the order summary to the database
                await _db.SaveChangesAsync(); // Save changes

                return RedirectToAction("OrderSuccess", new { id = orderSummery.Id });
            }

            return View();
        }


        public IActionResult OrderSuccess(int id)
        {


            var claim = _signInManager.IsSignedIn(User);
            if (claim)
            {
                var userId = _userManager.GetUserId(User);
                var UserCartRemove = _db.UserCarts.Where(u => u.UserId.Contains(userId)).ToList();
                var orderProcessed = _db.orderHeaders.FirstOrDefault(h => h.Id == id);
                //Update Payment status
                if (orderProcessed != null)
                {
                    if (orderProcessed.PaymentStatus == "Not Paid")
                    {
                        orderProcessed.PaymentStatus = "Paid";
                    }
                }
                //Add the items from cart to Order Details table
                foreach (var list in UserCartRemove)
                {
                    OrderDetails orderReceived = new OrderDetails()
                    {
                        OrderHeaderId = orderProcessed.Id,
                        ProductId = (int)list.ProductId,
                        Count = list.Quantity,
                    };

                    _db.orderDetails.Add(orderReceived);
                }
                //Removed items from cart for the current user after successully completing the payment process.
                _db.UserCarts.RemoveRange(UserCartRemove);
                _db.SaveChanges(true);
                var count = _db.UserCarts.Where(u => u.UserId.Contains(_userManager.GetUserId(User))).ToList().Count;
                HttpContext.Session.SetInt32(cartCount.sessionCount, count);

            }
            return View();
        }

        public IActionResult OrderHistory(string? status)
        {
            var userId = _userManager.GetUserId(User);
            List<UserOrderHeader> orderLists = new List<UserOrderHeader>();
            if (status != null && status != "ALL")
            {
                if (User.IsInRole("Admin"))
                {
                    orderLists = _db.orderHeaders.Where(u => u.OrderStatus == status).ToList();

                }
                else
                {
                    orderLists = _db.orderHeaders.Where(u => u.OrderStatus == status && u.UserId == userId).ToList();
                }
            }
            else
            {
                if (User.IsInRole("Admin"))
                {
                    orderLists = _db.orderHeaders.ToList();
                }
                else
                {
                    orderLists = _db.orderHeaders.Where(u => u.UserId == userId).ToList();

                }
            }
            return View(orderLists);
        }

        public IActionResult OrderDetails(int orderId)
        {
            OrderDetailsModelView = new OrderDetailsModelView();
            OrderDetailsModelView.UserOrderHeader = _db.orderHeaders.FirstOrDefault(u => u.Id == orderId);
            OrderDetailsModelView.UserProductList = _db.orderDetails.Include(u => u.Product).Where(u => u.OrderHeaderId == orderId).ToList();
            return View(OrderDetailsModelView);
        }
    }
}