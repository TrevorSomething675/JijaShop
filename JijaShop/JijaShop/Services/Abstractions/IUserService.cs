using JijaShop.Models.DTOModels;

namespace JijaShop.Services.Abstractions
{
	public interface IUserService
	{
		public Task<bool> CreateNewUser(UserDto userDto);
		public Task<bool> UpdateUser(UserDto userDto);
        public Task<List<UserDto>> GetUsers();
	}
}
