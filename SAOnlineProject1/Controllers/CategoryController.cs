using Microsoft.AspNetCore.Mvc;

namespace SAOnlineProject1.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
