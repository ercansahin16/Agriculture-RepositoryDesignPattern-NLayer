﻿using AgriculturePresentation.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AgriculturePresentation.Controllers
{
   [AllowAnonymous]
   public class LoginController : Controller
   {
      private readonly UserManager<IdentityUser> _userManager;
      private readonly SignInManager<IdentityUser> _signInManager;

      public LoginController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
      {
         _userManager = userManager;

         _signInManager = signInManager;
      }
    
      [HttpGet]
      public IActionResult Index()
      {

         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Index(LoginViewModel loginViewModel)
      {
         if (ModelState.IsValid)
         {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.username, loginViewModel.password, false, false);
            if (result.Succeeded)
            {
               return RedirectToAction("Index", "News");
            }else
            {
               return RedirectToAction("Index");

            }
         }
         return View();
        
      }


      [HttpGet]
      public IActionResult SignUp()
      {
         return View();
      }
      [HttpPost]
      public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
      {
         IdentityUser ıdentityUser = new()
         {
            Id="1",
            UserName = registerViewModel.userName,
            Email = registerViewModel.email
         };
         if (registerViewModel.Password == registerViewModel.ConfirmPassword)
         {
            var result = await _userManager.CreateAsync(ıdentityUser, registerViewModel.Password);
            if (result.Succeeded)
            {
               return RedirectToAction("Index");
            }
            else
            {
               foreach (var item in result.Errors)
               {
                  ModelState.AddModelError("", item.Description);
               }
            }
            
         }

         return View();
      }
   }
}
