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
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserditViewModel model = new UserditViewModel();
            model.Name = value.Name;
            model.SurName = value.SurName;
            model.EMail = value.Email;
            model.City = value.City;
            model.UserName = value.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.SurName = model.SurName;
            user.Name = model.Name;
            user.City = model.City;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
            

        }

    }
}