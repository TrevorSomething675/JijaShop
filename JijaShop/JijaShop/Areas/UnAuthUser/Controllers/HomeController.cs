using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UnAuthUser.Controllers
{
	[Area("UnAuthUser")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
