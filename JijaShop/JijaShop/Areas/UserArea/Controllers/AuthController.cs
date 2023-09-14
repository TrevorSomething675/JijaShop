using System.Security.Cryptography;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using JijaShop.Models.Entities;
using JijaShop.Services;
using AutoMapper;

namespace JijaShop.Areas.UserArea.Controllers
{
	[Area("UserArea")]
	public class AuthController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IdentityService _identityService;

		public AuthController(IMapper mapper, IdentityService identityService)
		{
			_identityService = identityService;
			_mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UserDto userDto)
		{
			CreatePasswordHash(userDto.UserDtoPassword, out byte[] passwordHash, out byte[] passwordSalt);

			var user = _mapper.Map<User>(userDto);
			user.UserPasswordHash = passwordHash;
			user.UserPasswordSalt = passwordSalt;

			await _identityService.RegisterUser(user);

			return Ok(user);
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login(UserDto userDto)
		{
			var user = _mapper.Map<User>(userDto);
			await _identityService.LoginUser(user);

			return Ok(user);
		}

		private void CreatePasswordHash(string? password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}
	}
}