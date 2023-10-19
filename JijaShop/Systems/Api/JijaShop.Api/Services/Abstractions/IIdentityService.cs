using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.Services.Abstractions
{
    public interface IIdentityService
    {
        public bool RegisterUser(UserDto userDto, out string response);
        public bool LoginUser(UserDto userDto, out string response);
    }
}
