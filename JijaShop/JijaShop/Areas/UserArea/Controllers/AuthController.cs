using Microsoft.AspNetCore.Authorization;
using JijaShop.Services.Abstractions;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class AuthController : Controller
	{
		private readonly IIdentityService _identityService;

		public AuthController(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		//[HttpPost("{area}/{controller}/register")]
		[HttpPost]
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

		//[HttpPost("{area}/{controller}/login")]
		[HttpPost]
		public async Task<IActionResult> Login(UserDto userDto)
		{
			var result = _identityService.LoginUser(userDto, out string response);

			if (result)
			{
				return Ok(new { token = response });
			}
			else
				return BadRequest(response);
		}

		[HttpGet]
		public async Task<IActionResult> Login()
		{
			return View();
		}

		[HttpGet("GetInfo"), Authorize]
		public async Task<IActionResult> GetInfo()
		{
			return Ok("Jija");
		}
	}
}
