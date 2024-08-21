using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class VitrinController : Controller
   {
      [AllowAnonymous]
      public IActionResult Index()
		{
			return View();
		}
	}
}
