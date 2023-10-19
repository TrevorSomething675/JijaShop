using JijaShop.Api.Areas.Admin.ViewModels;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JijaShop.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsers();
            var model = new AdminUsersViewModel
            {
                Users = users
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersPartial()
        {
            var model = await _userService.GetUsers();

            return PartialView("GetUsersPartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserDto userDto)
        {
            var result = await _userService.CreateNewUser(userDto);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            var result = await _userService.UpdateUser(userDto);

            if (result)
                return Ok();
            else
                return BadRequest();
        }


    }
}
