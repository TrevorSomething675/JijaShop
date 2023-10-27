using JijaShop.Api.Data.Models.AuthDtoModels;
using JijaShop.Api.Data.Models.AuthEntities;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Extentions.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using JijaShop.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IRolesRepository _rolesRepository;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthController(UserManager<User> userManager, IMapper mapper, IRolesRepository rolesRepository, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _rolesRepository = rolesRepository;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.UserEmail);

            if (!ModelState.IsValid)
                return BadRequest("Критическая ошибка");

            if (user != null)
                return BadRequest("Такой пользователь уже существует");

            var resultUser = _mapper.Map<User>(userDto);

            var result = await _userManager.CreateAsync(resultUser, userDto.UserPassword);

            if (!result.Succeeded)
                return BadRequest();

            await _userManager.AddToRoleAsync(resultUser, UserRoles.User);

            return await Login(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Критическая ошибка");

            var user = await _userManager.FindByEmailAsync(userDto.UserEmail);

            if (user == null)
                return BadRequest("Пользователь не зарегистрирован");

            if (!await _userManager.CheckPasswordAsync(user, userDto.UserPassword))
                return BadRequest("Неверный пароль");

            var role = await _rolesRepository.GetRole(1);
            var roles = new List<IdentityRole<int>> { role };

            var accessToken = _tokenService.CreateAccessToken(userDto, roles);
            user.AccessToken = accessToken;

            await _userManager.UpdateAsync(user);

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok(accessToken);
        }

        //public async Task<IActionResult> Login(UserDto userDto)
        //{
        //    var result = _identityService.LoginUser(userDto, out string response);

        //    if (result)
        //    {
        //        var cookieOptions = new CookieOptions
        //        {
        //            HttpOnly = true,
        //            Secure = true,
        //            SameSite = SameSiteMode.Strict,
        //        };

        //        Response.Cookies.Append("Token", response, cookieOptions);
        //        return Ok(new { token = response });
        //    }
        //    else
        //    {
        //        return BadRequest(response);
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpGet, Authorize(Roles = "User")]
        public async Task<IActionResult> GetInfo()
        {
            return Ok("Jija");
        }
    }
}
