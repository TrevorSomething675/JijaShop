using JijaShop.Repositories.Abstractions;
using System.Security.Cryptography;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Linq.Expressions;

namespace JijaShop.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        
        public AuthController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            CreatePasswordHash(userDto.UserDtoPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<Models.Entities.User>(userDto);
            user.UserName = userDto.UserDtoName;
            user.UserPasswordHash = passwordHash;
            user.UserPasswordSalt = passwordSalt;

            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var user = _mapper.Map<Models.Entities.User>(userDto);
            Expression<Func<Models.Entities.User, bool>> filter = user => user.UserName == userDto.UserDtoName;
            user = await _userRepository.GetUser(filter);

            return Ok(user);
        }
        private void CreatePasswordHash(string? password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
