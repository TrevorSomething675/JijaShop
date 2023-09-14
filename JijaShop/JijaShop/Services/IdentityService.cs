using JijaShop.Repositories.Abstractions;
using System.Security.Cryptography;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;

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
				if (!IsRegistered(userDto))
				{
					CreatePasswordHash(userDto.UserPassword, out byte[] passwordHash, out byte[] passwordSalt);
					var user = _mapper.Map<User>(userDto);
					user.UserPasswordHash = passwordHash;
					user.UserPasswordSalt = passwordSalt;
	
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
				if (IsRegistered(userDto) && IsValidPasswordHash(userDto))
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

		private bool IsRegistered(UserDto userDto)
		{
			var user = _userRepository.GetUser(filterUser => filterUser.UserName == userDto.UserName);

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

		private bool IsValidPasswordHash(UserDto userDto)
		{
			var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName);

			if(user?.UserPasswordHash != null && user?.UserPasswordSalt != null)
			{
				try
				{
					using (var hmac = new HMACSHA512(user.UserPasswordSalt))
					{
						var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userDto.UserPassword));
						return computedHash.SequenceEqual(user.UserPasswordHash);
					}
				}
				catch(Exception ex)
				{
					_logger.LogInformation($"{ex.Message}");
					return false;
				}
			}
			else
			{
				return false;
			}
		}
	}
}