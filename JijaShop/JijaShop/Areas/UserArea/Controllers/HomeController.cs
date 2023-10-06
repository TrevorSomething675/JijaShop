using JijaShop.Areas.UserArea.ViewModels;
using JijaShop.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Info()
		{
			return View();
		}

		public IActionResult Favorites()
		{
			return View();
		}
    }
}