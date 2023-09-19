using JijaShop.Models.DTOModels;

namespace JijaShop.Services.Abstractions
{
	public interface IUserService
	{
		public Task CreateNewUser(UserDto userDto);
		public Task<List<UserDto>> GetUsers();
	}
}
