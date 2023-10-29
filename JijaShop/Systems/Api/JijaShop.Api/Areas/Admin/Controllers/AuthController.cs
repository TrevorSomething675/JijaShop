using JijaShop.Api.Repositories.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Serilog;
using JijaShop.Api.Data.Models.AuthDtoModels;

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
