using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
