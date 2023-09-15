using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using JijaShop.Services;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class AuthController : Controller
	{
		private readonly IdentityService _identityService;
		private readonly ILogger<AuthController> _logger;

		public AuthController(IdentityService identityService, ILogger<AuthController> logger)
		{
			_logger = logger;
			_identityService = identityService;
		}
		
		[HttpPost("register")]
		public IActionResult Register(UserDto userDto)
		{
			_logger.LogInformation("Test");
			var result = _identityService.RegisterUser(userDto, out string message);

			if (result)
				return Ok(userDto);
			else
				return BadRequest(message);
		}

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpPost("login")]
		public async Task<IActionResult> Login(UserDto userDto)
		{
			var result = _identityService.LoginUser(userDto, out string message);

			if (result)
				return Ok(userDto);
			else
				return BadRequest(message);
		}

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}