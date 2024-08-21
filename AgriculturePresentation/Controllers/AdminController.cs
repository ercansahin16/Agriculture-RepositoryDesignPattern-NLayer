using BusinessLayer.Abstract;
using BusinessLayer.ValidationRuless;
using DataAccessLayer.Contexts;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
   public class AdminController : Controller
   {
      private readonly IAdminService _adminService;

      public AdminController(IAdminService adminService)
      {
         _adminService = adminService;
      }

      public IActionResult Index()
      {
         var values = _adminService.GetListAll();
         return View(values);
      }


      public IActionResult InsertAdmin()
      {
         return View();
      }

      [HttpPost]
      public IActionResult InsertAdmin(Admin admin)
      {
         _adminService.Insert(admin);
         return RedirectToAction("Index");
      }

      public IActionResult DeleteAdmin(int id)
      {
         var values = _adminService.GetById(id);
         _adminService.Delete(values);
         return RedirectToAction("Index");
      }


      public IActionResult EditAdmin(int id)
      {
         var values = _adminService.GetById(id);
         return View(values);
      }

      [HttpPost]
      public IActionResult EditAdmin(Admin admin)
      {
         _adminService.Update(admin);
         return RedirectToAction("Index");

      }
      public IActionResult Istatistik()
      {
         AgricultureContext context = new AgricultureContext();
         ViewBag.cart = context.Teams.Count();
         ViewBag.service=context.Services.Count();
         ViewBag.cantact=context.Contacts.Count();
         ViewBag.date = DateTime.Now.ToString("dd.MM.yyyy");
         ViewBag.newstrue=context.Newses.Where(x=>x.Status==true).Count();  
         ViewBag.newsfalse=context.Newses.Where(x=>x.Status==false).Count();  
         ViewBag.ImageTitle=context.Images.OrderByDescending(x=>x.Title).Count();
         ViewBag.admincount=context.Admins.Count();
    
         return View();
      }




   }
}
