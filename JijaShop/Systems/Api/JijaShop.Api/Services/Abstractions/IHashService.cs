using JijaShop.Api.Data.Models.AuthDtoModels;

namespace JijaShop.Api.Services.Abstractions
{
    public interface IHashService
    {
        public bool IsValidPasswordHash(UserDto userDto);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    }
}
