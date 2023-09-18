using Microsoft.AspNetCore.Authorization;
using JijaShop.Services.Abstractions;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Serilog;

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
				HttpContext.Response.Headers.Add("Authorization", $"Bearer {response}");
				Log.Information(HttpContext.Response.Headers.Authorization);
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
			return Ok("Jija");
		}
	}
}