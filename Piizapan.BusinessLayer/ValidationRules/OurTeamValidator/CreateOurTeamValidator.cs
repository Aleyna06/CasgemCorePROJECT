using FluentValidation;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piizapan.BusinessLayer.ValidationRules.OurTeamValidator
{
    public class CreateOurTeamValidator:AbstractValidator<OurTeam>
    {
        public CreateOurTeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyİsim Alanı Boş Geçilemez");

            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yaypınız");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter veri girişi yaypınız ");
          
        }
    }
}
