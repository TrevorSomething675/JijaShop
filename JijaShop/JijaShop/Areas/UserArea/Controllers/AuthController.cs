using Microsoft.AspNetCore.Authorization;
using JijaShop.Services.Abstractions;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class AuthController : Controller
	{
		private readonly IIdentityService _identityService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(IIdentityService identityService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
		{
			_identityService = identityService;
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> Register(UserDto userDto)
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

		[HttpPost]
		public async Task<IActionResult> Login(UserDto userDto)
		{
			var result = _identityService.LoginUser(userDto, out string response);

			if (result)
			{
                return Ok(new { token = response });
			}
			else
			{
				return BadRequest(response);
			}
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
