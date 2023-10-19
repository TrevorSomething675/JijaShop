using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.Moderator.Controllers
{
    [Area("Moderator")]
	public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
