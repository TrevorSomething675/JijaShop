using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Services.Abstractions;
using System.Security.Cryptography;
using System.Text;
using JijaShop.Api.Data.Models.AuthDtoModels;

namespace JijaShop.Api.Services
{
    public class HashService : IHashService
    {
        private readonly IUserRepository _userRepository;
        public HashService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool IsValidPasswordHash(UserDto userDto)
        {
            var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName).Result;

            using (var hmac = new HMACSHA256(user.UserPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.UserPassword));
                return computedHash.SequenceEqual(user.UserPasswordHash);
            }
        }
    }
}
