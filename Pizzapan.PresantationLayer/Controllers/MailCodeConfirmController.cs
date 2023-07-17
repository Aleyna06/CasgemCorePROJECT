using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresantationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.Controllers
{
    public class MailCodeConfirmController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MailCodeConfirmController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //Bir tane mai lkodu   onay sayfası yapın Register sayfasından sonra kullanıcı bir sayafaya yönlendirsin .
        //Bu sayfaya kullanıcının register olduğu mail adresiin readonly olan bir innputa taşıyın .kullanıcı hemen alta başka bir input onay kodunu girsin.Eğer kullanıcının giridği
        //onay odu ile ilgili mailin onay odu aynı ise kullanıcının email confirmed sütunu true olsun ve login sayfasına yönlendirsin
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.UserName = TempData["UserName"];
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
