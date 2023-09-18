using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.Moderator.Controllers
{
    [Area("Moderator")]
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
