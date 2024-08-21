using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRuless
{
   public class ImageValidator : AbstractValidator<Image>
   {
      public ImageValidator()
      {
         RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel Başlığını Boş Geçemezsiniz...");
         RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel Açıklamasını Girmelisiniz.");
         RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Url Girmelisiniz.");
         RuleFor(x => x.Description).MaximumLength(50).WithMessage("Açıklamaya Enfazla 50 karakter giriniz...");
         RuleFor(x => x.Description).MinimumLength(10).WithMessage("Açıklamaya En az 10 karakter giriniz...");


      }
   }
}
