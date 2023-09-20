using JijaShop.Repositories.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Serilog;

namespace JijaShop.Areas.Admin.Controllers
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

		[NonAction]
		private bool IsRegistered(UserDto userDto)
		{
			var user = _userRepository.GetUser(filterUser => filterUser.UserName == userDto.UserName);

			if (user != null)
				return true;
			else
				return false;
		}

		[NonAction]
		private bool IsValidPasswordHash(UserDto userDto)
		{
			var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName);

			using (var hmac = new HMACSHA256(user.UserPasswordSalt))
			{
				var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.UserPassword));
				return computedHash.SequenceEqual(user.UserPasswordHash);
			}
		}

		[NonAction]
		private string CreateToken(UserDto userDto)
		{
			try
			{
				var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName);

				List<Claim> claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(ClaimTypes.Role, "Admin"),
				};
				var key = new SymmetricSecurityKey(Encoding.UTF8
					.GetBytes(_configuration.GetSection("AppSettings:SecretKeyForToken").Value));

				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

				var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.UtcNow.AddDays(7),
					signingCredentials: creds);

				var jwt = new JwtSecurityTokenHandler().WriteToken(token);

				return jwt;
			}
			catch (Exception ex)
			{
				Log.Logger.Error($"Не удалось создать токен {ex.Message}");
				return string.Empty;
			}
		}
	}
}
