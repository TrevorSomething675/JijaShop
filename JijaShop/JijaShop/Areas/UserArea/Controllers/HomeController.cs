using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			Log.Information($"[Index] {HttpContext.Response.Headers.Authorization}");
			return View();
		}
		
		public IActionResult Products()
		{
			return View();
		}

		public IActionResult Info()
		{
			return View();
		}
	}
}
