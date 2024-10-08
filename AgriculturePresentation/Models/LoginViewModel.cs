﻿using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
   public class LoginViewModel
   {

      [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz...")]
      public string username { get; set; }

      [Required(ErrorMessage = "Lütfen şifrenizi giriniz...")]
      public string password { get; set; } 
   }
}
