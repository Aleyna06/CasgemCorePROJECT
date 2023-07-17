using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Pizzapan.EntityLayer.Concrete;
using Pizzapan.PresantationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.Controllers
{
   
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //Identity tanımlaması için 

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {

            Random rnd = new Random();
            int x= rnd.Next(100000, 100000);

            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                SurName = model.SurName,
                Email = model.EMail,
                UserName = model.UserName,
                ConfirmCode = x
            };
            if (model.Password == model.ConfirmPassword )
            {
               
                var result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    #region
                    MimeMessage mimesaage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "celikaleyna71@gmail.com");
                    mimesaage.From.Add(mailboxAddressFrom);

                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.EMail);
                    mimesaage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Giriş yapabilmek için onaylama kodunuz " + x;
                    mimesaage.Body = bodyBuilder.ToMessageBody();

                    mimesaage.Subject = "Doğrulama Kodu";

                    SmtpClient smptpClient = new SmtpClient();
                    smptpClient.Connect("smtp.gmail.com", 587, false);
                    smptpClient.Authenticate("celikaleyna71@gmail.com", "aqcpjmmvxvyswoui");
                    smptpClient.Send(mimesaage);
                    smptpClient.Disconnect(true);
                    #endregion
                    TempData["UserName"] = appUser.UserName;
                    return RedirectToAction("Index", "MailCodeConfirm");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            else
            {
                ModelState.AddModelError("","Şifreler Eşleşmiyor");
            }
            return View(); 

        }
    }
}