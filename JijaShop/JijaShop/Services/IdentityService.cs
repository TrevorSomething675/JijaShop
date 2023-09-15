using JijaShop.Repositories.Abstractions;
using System.Security.Cryptography;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using System.Security.Claims;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using Serilog;

namespace JijaShop.Services
{
	public class IdentityService
	{
		private readonly ILogger<IdentityService> _logger;
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		public IdentityService(IUserRepository userRepository, ILogger<IdentityService> logger, IMapper mapper, IConfiguration configuration) 
		{ 
			_userRepository = userRepository;
			_configuration = configuration;
			_logger = logger;
			_mapper = mapper;
		}

		public bool RegisterUser(UserDto userDto, out string message)
		{
			if (IsRegistered(userDto))
			{
				message = $"Пользователь с таким именем уже существует";
				return false;
			}
			try
			{
				CreatePasswordHash(userDto.UserPassword, out byte[] passwordHash, out byte[] passwordSalt);

				var user = _mapper.Map<User>(userDto);
				user.UserPasswordHash = passwordHash;
				user.UserPasswordSalt = passwordSalt;

				_userRepository.CreateUser(user);
				message = "Упешная регистрация";
				return true;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.Message);
				message = "Не удалось выполнить регистрацию";
				return false;
			}
        }

		public bool LoginUser(UserDto userDto, out string message)
		{
			if (!IsRegistered(userDto))
			{
				message = "Пользователя с таким именем не существует";
				return false;
			}
			if (!IsValidPasswordHash(userDto))
			{
				message = "Неверный пароль";
				return false;
			}
			try
			{
				message = "Успешно";
				CreateToken(userDto);
				return true;
			}
			catch(Exception ex)
			{
				message = "Возникла ошибка";
				_logger.LogError(ex.Message);
				return false;
			}
		}

		private bool IsRegistered(UserDto userDto)
		{
			var user = _userRepository.GetUser(filterUser => filterUser.UserName == userDto.UserName);

			if (user != null)
				return true;
			else
				return false;
		}

		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA256())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			}
		}

		private bool IsValidPasswordHash(UserDto userDto)
		{
			var user = _userRepository.GetUser(userFilter=>userFilter.UserName == userDto.UserName);

			using (var hmac = new HMACSHA256(user.UserPasswordSalt))
			{
				var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.UserPassword));
				return computedHash.SequenceEqual(user.UserPasswordHash);
			}
		}

		private string CreateToken(UserDto userDto)
		{
			try
			{
				var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName);

				List<Claim> claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName)
				};
				var key = new SymmetricSecurityKey(Encoding.UTF8
					.GetBytes(_configuration.GetSection("AppSettings:SecretKeyForToken").Value));

				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

				var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.UtcNow.AddSeconds(30),
					signingCredentials: creds);

				var jwt = new JwtSecurityTokenHandler().WriteToken(token);

				return jwt;
			}
			catch(Exception ex)
			{
				Log.Logger.Error($"Не удалось создать токен {ex.Message}");
				return string.Empty;
			}
		}
	}
}