using JijaShop.Api.Data.Models.AuthDtoModels;
using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Extensions.SettingsModel;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using JijaShop.Extentions;
using System.Text;

namespace JijaShop.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILogger<TokenService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IdentitySettings _idetitySettings;

        public TokenService(ILogger<TokenService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _idetitySettings = Settings.Load<IdentitySettings>("Identity");
        }

        public string CreateAccessToken(UserDto userDto, List<IdentityRole<int>> roles)
        {
            try
            {
                var user = _userRepository.GetUser(userFilter => userFilter.UserName == userDto.UserName).Result;

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(ClaimTypes.Role, string.Join(" ", roles.Select(role=>role.Name)))
                };

                var creds = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_idetitySettings.SecretKeyForToken)
                        ),
                        SecurityAlgorithms.HmacSha256
                    );

                var token = new JwtSecurityToken(
                    _idetitySettings.Issuer,
                    _idetitySettings.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(2),
                    //expires: DateTime.UtcNow.AddHours(_idetitySettings.ExpTimeHours),
                    signingCredentials: creds
                    );
                var jwtHandler = new JwtSecurityTokenHandler().WriteToken(token);

                return jwtHandler;

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Не удалось создать токен [{ex.Message}]");
                return "InvalidToken";
            }
        }
    }
}
