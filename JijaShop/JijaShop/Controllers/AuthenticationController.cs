using JijaShop.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        //public IActionResult Logout()
        //{
        
        //}
        //public IActionResult Register()
        //{

        //}

        public IActionResult LoginAccess(User user)
        {
            return Json(user);
        }
    }
}
