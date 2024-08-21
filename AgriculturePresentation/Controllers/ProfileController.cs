using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
   public class ProfileController : Controller
   {
      private readonly UserManager<IdentityUser> _userManager;

      public ProfileController(UserManager<IdentityUser> userManager)
      {
         _userManager = userManager;
      }

      [HttpGet]
      public async Task<IActionResult> Index()
      {
         var values = await _userManager.FindByNameAsync(User.Identity.Name);
         UserEditViewMode userEditViewMode=new UserEditViewMode();
         userEditViewMode.Mail = values.Email;
         userEditViewMode.Phone = values.PhoneNumber;

         return View(userEditViewMode);
      }
      [HttpPost]
      public async Task<IActionResult> Index(UserEditViewMode p)
      {
         var values = await _userManager.FindByNameAsync(User.Identity.Name);
         values.Email = p.Mail;
         values.PhoneNumber = p.Phone;
         values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
         var result= await _userManager.UpdateAsync(values);

         if (result.Succeeded)
         {
            return RedirectToAction("Index", "Login");
         }
         return View();
      }


      }
}
