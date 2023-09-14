using JijaShop.Repositories.Abstractions;
using JijaShop.Models.Entities;
using System.Linq.Expressions;
using JijaShop.Models.DTOModels;
using AutoMapper;
using System.Security.Cryptography;

namespace JijaShop.Services
{
	public class IdentityService
	{
		private readonly IUserRepository _userRepository;
		private readonly ILogger<IdentityService> _logger;
		private readonly IMapper _mapper;
		public IdentityService(IUserRepository userRepository, ILogger<IdentityService> logger, IMapper mapper) 
		{ 
			_userRepository = userRepository;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<bool> RegisterUser(UserDto userDto)
		{
			try
			{
				CreatePasswordHash(userDto.UserPassword, out byte[] passwordHash, out byte[] passwordSalt);
	
				var user = _mapper.Map<User>(userDto);
				user.UserPasswordHash = passwordHash;
				user.UserPasswordSalt = passwordSalt;
	
				if (!IsRegister(user))
				{
					await _userRepository.CreateUser(user);
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex.Message);
				return false;
			}
		}

		public async Task<bool> LoginUser(UserDto userDto)
		{
			try
			{
				var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName);
				var result = VerifyPasswordHash(userDto.UserPassword, user.UserPasswordHash, user.UserPasswordSalt);

				if (IsRegister(user) && result)
					return true;
				else
					return false;
			}
			catch(Exception ex)
			{
				_logger.LogInformation($"{ex.Message}");
				return false;
			}
		}
		private bool IsRegister(User requestUser)
		{
			var user = _userRepository.GetUser(filterUser => filterUser.UserName == requestUser.UserName);

			if(user != null)
				return true;
			else
				return false;
		}

		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}
		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			try
			{
				using (var hmac = new HMACSHA512(passwordSalt))
				{
					var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
					return computedHash.SequenceEqual(passwordHash);
				}
			}
			catch(Exception ex)
			{
				_logger.LogInformation($"{ex.Message}");
				return false;
			}
		}
	}

}
