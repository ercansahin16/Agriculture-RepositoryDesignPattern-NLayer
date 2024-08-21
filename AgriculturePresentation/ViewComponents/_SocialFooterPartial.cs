using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
   public class _SocialFooterPartial:ViewComponent
   {
      private readonly ISocialMediaService _mediaService;

      public _SocialFooterPartial(ISocialMediaService mediaService)
      {
         _mediaService = mediaService;
      }

      public IViewComponentResult Invoke()
      {
         var values = _mediaService.GetListAll();
         return View(values); 
      }
   }
}
