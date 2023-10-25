using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var result = _identityService.RegisterUser(userDto, out string response);

            if (result)
            {
                Response.Cookies.Append("Bearer", response);
                return Ok(userDto);
            }
            else
                return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var result = _identityService.LoginUser(userDto, out string response);

            if (result)
            {
                Response.Cookies.Append("Bearer", response);
                return Ok(new { token = response });
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetInfo()
        {
            return Ok("Jija");
        }
    }
}
