using JijaShop.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;


namespace JijaShop.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}