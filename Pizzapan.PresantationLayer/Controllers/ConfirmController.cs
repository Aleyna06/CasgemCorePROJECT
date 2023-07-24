using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresantationLayer.Models;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.Controllers
{
    public class ConfirmController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.username = TempData["UserName"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(vm.UserName);
            if (user.ConfirmCode.ToString() == vm.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
