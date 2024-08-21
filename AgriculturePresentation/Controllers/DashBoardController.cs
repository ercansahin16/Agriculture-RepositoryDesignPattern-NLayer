using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
   public class DashBoardController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
