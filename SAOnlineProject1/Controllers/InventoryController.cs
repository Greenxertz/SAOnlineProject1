using Microsoft.AspNetCore.Mvc;

namespace SAOnlineProject1.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
