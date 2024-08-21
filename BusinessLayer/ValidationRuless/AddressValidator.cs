using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRuless
{
   public class AddressValidator : AbstractValidator<Adress>
   {

      public AddressValidator() 
      {
         RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama-1 Boş Geçemezsiniz...");
         RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama-2 Boş Geçemezsiniz...");
         RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama-3 Boş Geçemezsiniz...");
         RuleFor(x => x.Description4).NotEmpty().WithMessage("Açıklama-4 Boş Geçemezsiniz...");
         RuleFor(x => x.Mapinfo).NotEmpty().WithMessage("Harita bilgisi boş geçilemez..");
      }
   }
}
