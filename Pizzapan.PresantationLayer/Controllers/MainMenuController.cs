using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresantationLayer.Controllers
{
    public class MainMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
