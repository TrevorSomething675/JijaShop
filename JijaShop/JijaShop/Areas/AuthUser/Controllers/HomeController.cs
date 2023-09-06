using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.User.Controllers
{
    [Area("AuthUser")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
