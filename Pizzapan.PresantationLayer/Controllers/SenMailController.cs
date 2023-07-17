using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Pizzapan.PresantationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.Controllers
{
    public class SenMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimesaage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "celikaleyna71@gmail.com");
            mimesaage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimesaage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            mimesaage.Body = bodyBuilder.ToMessageBody();

            mimesaage.Subject = mailRequest.Subject;

            SmtpClient smptpClient = new SmtpClient();
            smptpClient.Connect("smtp.gmail.com",587,false);
            smptpClient.Authenticate("celikaleyna71@gmail.com", "aqcpjmmvxvyswoui");
            smptpClient.Send(mimesaage);
            smptpClient.Disconnect(true);


            return View();
        }
    }
}
