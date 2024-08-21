using BusinessLayer.Abstract;
using BusinessLayer.ValidationRuless;
using EntityLayer.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
   public class ImageController : Controller
   {
      private readonly IImageService _imageService;
public ImageController(IImageService imageService)
      {
         _imageService = imageService;
      }

      public IActionResult Index()
      {
         var values =_imageService.GetListAll();
         return View(values);
      }

      public IActionResult AddImage()
      {
         return View();
      }

      [HttpPost]
      public IActionResult AddImage(Image image)
      {
         ImageValidator validationRules = new ImageValidator();
         ValidationResult validationResult = validationRules.Validate(image);
         if (validationResult.IsValid)
         {
            _imageService.Insert(image);
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

      public IActionResult DeleteImage(int id)
      {
         var values = _imageService.GetById(id);
         _imageService.Delete(values);
         return RedirectToAction("Index");
      }


      public IActionResult EditImage(int id)
      {
         var values = _imageService.GetById(id);
         return View(values);
      }
      [HttpPost]
      public IActionResult EditImage(Image image)
      {
         ImageValidator validationRules = new ImageValidator();
         ValidationResult validationResult = validationRules.Validate(image);
         if (validationResult.IsValid)
         {
            _imageService.Update(image);
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
