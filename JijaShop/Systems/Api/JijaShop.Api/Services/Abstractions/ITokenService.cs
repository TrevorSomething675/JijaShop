using JijaShop.Api.Data.Models.AuthDtoModels;
using Microsoft.AspNetCore.Identity;

namespace JijaShop.Api.Services.Abstractions
{
    public interface ITokenService
    {
        public string CreateAccessToken(UserDto userDto, List<IdentityRole<int>> roles);
    }
}
