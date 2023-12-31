﻿using JijaShop.Api.Data.Models.AuthDtoModels;

namespace JijaShop.Api.Services.Abstractions
{
    public interface IUserService
    {
        public Task<bool> CreateNewUser(UserDto userDto);
        public Task<bool> UpdateUser(UserDto userDto);
        public Task<List<UserDto>> GetUsers();
    }
}
