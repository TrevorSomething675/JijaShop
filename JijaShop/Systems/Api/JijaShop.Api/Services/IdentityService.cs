using JijaShop.Services.Settings.SettingsModel;
using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Data.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Serilog;
using JijaShop.Api.Data;

namespace JijaShop.Api.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ILogger<IdentityService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IdentitySettings _identityService;
        private readonly IMapper _mapper;
        public IdentityService(IUserRepository userRepository, ILogger<IdentityService> logger, IMapper mapper)
        {
            _identityService = Settings.Settings.Load<IdentitySettings>("Identity");
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public bool RegisterUser(UserDto userDto, out string response)
        {
            if (IsRegistered(userDto))
            {
                response = $"Пользователь с таким именем уже существует";
                return false;
            }
            try
            {
                CreatePasswordHash(userDto.UserPassword, out byte[] passwordHash, out byte[] passwordSalt);

                var user = _mapper.Map<User>(userDto);
                user.UserPasswordHash = passwordHash;
                user.UserPasswordSalt = passwordSalt;

                _userRepository.CreateUser(user);
                response = CreateToken(userDto);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = "Не удалось выполнить регистрацию";
                return false;
            }
        }

        public bool LoginUser(UserDto userDto, out string response)
        {
            if (!IsRegistered(userDto))
            {
                response = "Пользователя с таким именем не существует";
                return false;
            }
            if (!IsValidPasswordHash(userDto))
            {
                response = "Неверный пароль";
                return false;
            }
            try
            {
                response = CreateToken(userDto);
                return true;
            }
            catch (Exception ex)
            {
                response = "Возникла ошибка";
                _logger.LogError(ex.Message);
                return false;
            }
        }

        private bool IsRegistered(UserDto userDto)
        {
            var user = _userRepository.GetUser(filterUser => filterUser.UserName == userDto.UserName).Result;

            if (user != null)
                return true;
            else
                return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool IsValidPasswordHash(UserDto userDto)
        {
            var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName).Result;

            using (var hmac = new HMACSHA256(user.UserPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.UserPassword));
                return computedHash.SequenceEqual(user.UserPasswordHash);
            }
        }

        private string CreateToken(UserDto userDto)
        {
            try
            {
                var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName).Result;

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "User"),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_identityService.SecretKeyForToken!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(7),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Не удалось создать токен {ex.Message}");
                return string.Empty;
            }
        }
    }
}
