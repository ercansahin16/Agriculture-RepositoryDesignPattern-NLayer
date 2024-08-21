using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;
using EntityLayer.Entities;

namespace AgriculturePresentation.Controllers
{
   public class NewsController : Controller
   {
      private readonly INewsService _newsService;

      public NewsController(INewsService newsService)
      {
         _newsService = newsService;
      }

      public IActionResult Index()
      {
         var values = _newsService.GetListAll();
         return View(values);
      }
      public IActionResult InsertNews()
      {
         return View();
      }
      [HttpPost]
      public IActionResult InsertNews(News news)
      {
       
         _newsService.Insert(news);
         return RedirectToAction("Index");

      }

      public IActionResult DeleteNews(int id)
      {
         var values = _newsService.GetById(id);
         _newsService.Delete(values);
         return RedirectToAction("Index");
      }
      public IActionResult EditNews(int id)
      {
         var values = _newsService.GetById(id);
         return View(values);
      }
      [HttpPost]
      public IActionResult EditNews(News news)
      {
         _newsService.Update(news);
         return RedirectToAction("Index");
      }

      public IActionResult Status(int id)
      {
         var value=_newsService.GetById(id);
         if(value.Status==true)
         {
            value.Status = false;
            _newsService.Update(value);

         }
         else
         {
            value.Status = true;
            _newsService.Update(value);
         }

         return RedirectToAction("Index");
        
      }


   }
}
