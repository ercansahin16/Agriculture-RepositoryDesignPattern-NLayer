using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
   public class _DashBoardHeaderPartial : ViewComponent
   {

      public IViewComponentResult Invoke()
      {
         return View();
      }

   }
}
