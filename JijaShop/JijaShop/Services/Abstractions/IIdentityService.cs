using JijaShop.Models.DTOModels;

namespace JijaShop.Services.Abstractions
{
	public interface IIdentityService
	{
		public bool RegisterUser(UserDto userDto, out string response);
		public bool LoginUser(UserDto userDto, out string response);
	}
}