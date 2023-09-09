using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace JijaShop.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Log.Debug("index");
            return View();
        }
    }
}
