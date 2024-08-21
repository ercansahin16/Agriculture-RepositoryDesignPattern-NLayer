using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRuless
{
   public class TeamValidator : AbstractValidator<Team>
   {
      public TeamValidator()
      {
         RuleFor(x => x.PersonName).NotEmpty().WithMessage("Takım Arkadaşınızın İsmini Girmeniz Gerekiyor");
         RuleFor(x => x.Title).NotEmpty().WithMessage("Görevini Girmelisiniz.");
         RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Url Girmelisiniz.");
         RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("50 karakteri geçmeyiniz.");
         RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("5 karakterden az geçmeyiniz.");
         RuleFor(x => x.Title).MaximumLength(50).WithMessage("50 karakteri geçmeyiniz.");
         RuleFor(x => x.Title).MinimumLength(3).WithMessage("3 karakterden az geçmeyiniz.");
      }
   }
}
