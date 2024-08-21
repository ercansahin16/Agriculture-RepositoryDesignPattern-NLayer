using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
   public class RegisterViewModel
   {
      [Required(ErrorMessage = "Kullanıcı Adını Giriniz...")]
      public string userName { get; set; }

      [Required(ErrorMessage = "Mail Adresinizi Giriniz...")]
      public string email { get; set; }

      [Compare("Password", ErrorMessage = "Şifreler Uyumlu değil, Tekrar deneyin.")]
      [Required(ErrorMessage = "Şifrenizi Giriniz...")]
      public string ConfirmPassword { get; set; }


      [Required(ErrorMessage = "Şifrenizi Giriniz...")]
      public string Password { get; set; }


   }
}
