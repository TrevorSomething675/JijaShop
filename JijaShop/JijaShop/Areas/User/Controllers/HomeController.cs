using JijaShop.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
