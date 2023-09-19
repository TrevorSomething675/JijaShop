using JijaShop.Repositories.Abstractions;
using JijaShop.Services.Abstractions;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;

namespace JijaShop.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		public UserService(IUserRepository userRepository, IMapper mapper) 
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task CreateNewUser(UserDto userDto)
		{
			var user = _mapper.Map<User>(userDto);
			await _userRepository.CreateUser(user);
		}

		public async Task<List<UserDto>> GetUsers()
		{
			var users = await _userRepository.GetUsers();
			var usersDto = _mapper.Map<List<UserDto>>(users);

			return usersDto;
		}
	}
}
