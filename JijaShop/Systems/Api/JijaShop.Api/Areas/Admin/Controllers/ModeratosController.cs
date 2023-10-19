using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModeratorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
