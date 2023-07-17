using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzapan.PresantationLayer.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola Çok Kısa En Az {length} Karakter Girişi Yapınız !" //dolar işareti varsa dışarıdan parametre girişi var demektir
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az 1 tane küçük karakter giriniz"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {

                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az 1 tane büyük karakter giriniz"
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {

                Code = "PasswordRequiresDigit",
                Description = "Lütfen en az 1 tane sayı karakter giriniz"
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {

                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Lütfen en az 1 tane sembol karakter giriniz"
            };
        }
    }
}
