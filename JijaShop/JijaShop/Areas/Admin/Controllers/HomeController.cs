using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class HomeController : Controller
    { 
        public IActionResult Products()
        {
            return View();
        }
       
        public IActionResult Users() 
        {
            return View();
        }
    }
}
