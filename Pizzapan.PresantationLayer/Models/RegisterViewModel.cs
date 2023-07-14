using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="Ad Alanı boş geçilemez")]
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required(ErrorMessage = "EMail Alanı boş geçilemez")]
        public string EMail { get; set; }
        public string UserName { get; set; }
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
