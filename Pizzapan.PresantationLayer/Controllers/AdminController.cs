using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresantationLayer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
