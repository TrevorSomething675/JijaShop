using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			Log.Information("Index");
			return View();
		}
	}
}
