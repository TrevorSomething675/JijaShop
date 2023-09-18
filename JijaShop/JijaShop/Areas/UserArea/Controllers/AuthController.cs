using Microsoft.AspNetCore.Authorization;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using JijaShop.Services;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class AuthController : Controller
	{
		private readonly UserService _userService;
		private readonly IdentityService _identityService;

		public AuthController(IdentityService identityService, UserService userService)
		{
			_userService = userService;
			_identityService = identityService;
		}
		
		[HttpPost("register")]
		public IActionResult Register(UserDto userDto)
		{ 
			var result = _identityService.RegisterUser(userDto, out string response);

			if (result)
				return Ok(userDto);
			else
				return BadRequest(response);
		}

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

		[HttpPost("login")]
		public async Task<IActionResult> Login(UserDto userDto)
		{
			var result = _identityService.LoginUser(userDto, out string response);

			if (result)
			{
				return Ok(new {token = response});
			}
			else
				return BadRequest(response);
		}

		[HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

		[HttpGet("GetInfo"), Authorize(Roles = "User")]
		public async Task<IActionResult> GetInfo()
		{
			var userName = _userService.GetName();
			return Ok(userName);
		}
	}
}