using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
