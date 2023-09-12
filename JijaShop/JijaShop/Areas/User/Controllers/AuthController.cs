using JijaShop.Repositories.Abstractions;
using JijaShop.Models.DTOModels;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Areas.User.Controllers
{
    [Area("User")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            await _userRepository.CreateUser(userDto);

            return Ok(userDto);
        }
    }
}
