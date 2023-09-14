using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using JijaShop.Services;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class AuthController : Controller
	{
		private readonly IdentityService _identityService;

		public AuthController(IdentityService identityService)
		{
			_identityService = identityService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UserDto userDto)
		{
			var result = await _identityService.RegisterUser(userDto);

			if (result)
				return Ok(userDto);
			else
				return BadRequest("Пользователь с таким именем уже существует");
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(UserDto userDto)
		{
			var result = await _identityService.LoginUser(userDto);

			if (result)
				return Ok(userDto);
			else
				return BadRequest("Пользователя с таким именем не существует");
		}
	}
}