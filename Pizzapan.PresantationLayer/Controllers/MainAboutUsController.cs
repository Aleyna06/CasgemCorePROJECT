using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresantationLayer.Controllers
{
    public class MainAboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
