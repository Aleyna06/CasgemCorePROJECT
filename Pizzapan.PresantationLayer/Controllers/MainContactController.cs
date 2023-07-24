using Microsoft.AspNetCore.Mvc;

namespace Pizzapan.PresantationLayer.Controllers
{
    public class MainContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
