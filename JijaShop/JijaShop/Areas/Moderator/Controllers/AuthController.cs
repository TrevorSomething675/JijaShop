using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.Moderator.Controllers
{
    [Area("Moderator")]
	public class AuthController : Controller
    {
        public async Task<IActionResult> Register()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
