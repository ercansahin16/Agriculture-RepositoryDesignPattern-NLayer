using BusinessLayer.Abstract;
using BusinessLayer.ValidationRuless;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
   public class AddressController : Controller
   {
      private readonly IAddressSevices _addressSevices;

      public AddressController(IAddressSevices addressSevices)
      {
         _addressSevices = addressSevices;
      }

      public IActionResult Index()
      {
         var values = _addressSevices.GetListAll();
         return View(values);
      }
     
      public IActionResult EditAddress(int id)
      {
         var values = _addressSevices.GetById(id);
         return View(values);
      }
      [HttpPost]
      public IActionResult EditAddress(Adress adress)
      {
         AddressValidator validationRules = new AddressValidator();
         ValidationResult validationResult = validationRules.Validate(adress);
         if (validationResult.IsValid)
         {
            _addressSevices.Update(adress);
            return RedirectToAction("Index");
         }
         else
         {
            foreach (var item in validationResult.Errors)
            {
               ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

            }
         }
         return View();
      }

     

   }
}
