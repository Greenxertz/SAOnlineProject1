using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SAOnlineProject1.Models;

namespace SAOnlineProject1.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel vm = new LoginViewModel();
            ViewData["returnUrl"] = returnUrl;
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user == null)
                {
                    login.LoginStatus = "user does not exist";
                    return View(login);
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (returnUrl != null && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");

                    }
                }
                else
                {
                    login.LoginStatus = "Password incorrect";
                }
            }
            login.LoginStatus = "Invalid login attempt.";
            return View(login);
        }

        public IActionResult Register()
        {
            RegisterViewModel vm = new RegisterViewModel
            {
                User = new ApplicationUser()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            var user = new ApplicationUser
            {
                UserName = register.Username,
                Email = register.EmailAddress,
                FirstName = register.User.FirstName,
                LastName = register.User.LastName,
                Address = register.User.Address,
                City = register.User.City,
                PostalCode = register.User.PostalCode,
                Province = register.User.Province,
            };

            var Registration = await _userManager.CreateAsync(user, register.Password);
            if (Registration.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                register.StatusMessage = "Registraion was successful.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                register.StatusMessage = "Registraion was unsuccessful.";
            }

            return View(register);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
