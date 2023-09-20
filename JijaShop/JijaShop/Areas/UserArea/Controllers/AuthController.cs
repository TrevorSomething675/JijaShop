using Microsoft.AspNetCore.Authorization;
using JijaShop.Services.Abstractions;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Linq;

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

		[HttpPost("{area}/{controller}/register")]
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

		[HttpPost("{area}/{controller}/login")]
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

		[HttpGet("{area}/{controller}/GetInfo"), Authorize]
		public async Task<IActionResult> GetInfo()
		{
			return Ok("Jija");
		}
	}
}
