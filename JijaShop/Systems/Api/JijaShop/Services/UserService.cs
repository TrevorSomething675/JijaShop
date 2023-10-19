using JijaShop.Repositories.Abstractions;
using JijaShop.Services.Abstractions;
using AutoMapper;
using JijaShop.Data.Models.DTOModels;
using JijaShop.Data.Models.Entities;

namespace JijaShop.Services
{
    public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly ILogger<UserService> _logger;
		private readonly IMapper _mapper;
		public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger) 
		{
			_userRepository = userRepository;
			_mapper = mapper;
			_logger = logger;
		}

        public async Task<List<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
        }

		public async Task<bool> DeleteUser(UserDto userDto)
		{
			try
			{
				var user = _mapper.Map<User>(userDto);
				await _userRepository.DeleteUser(user);
				return true;
			}
			catch(Exception ex)
			{
				_logger.LogError($"{ex}");
				return false;
			}
		}

        public async Task<bool> CreateNewUser(UserDto userDto)
		{
			try
			{
				var user = _mapper.Map<User>(userDto);
				await _userRepository.CreateUser(user);
				return true;
			}
			catch(Exception ex)
			{
				_logger.LogError($"{ex}");
				return false;
			}
		}

		public async Task<bool> UpdateUser(UserDto userDto)
		{
			try
			{
				var user = _mapper.Map<User>(userDto);
				await _userRepository.UpdateUser(user);
				return true;
			}
			catch(Exception ex)
			{
				_logger.LogError($"{ex}");
				return false;
			}
		}
	}
}
