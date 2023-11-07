﻿using JijaShop.Api.Repositories.Abstractions;
using System.Linq.Expressions;
using JijaShop.Api.Data;
using Microsoft.EntityFrameworkCore;
using JijaShop.Api.Data.Models.AuthEntities;

namespace JijaShop.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly MainContext _context;
        public UserRepository(MainContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _context.Users
                .Include(user=>user.CartProduct)
                .Include(user=>user.FavoriteProduct)
                .ToListAsync();
            return users;
        }

        public async Task<User> GetUser(Expression<Func<User, bool>> filter = null)
        {
            var user = await _context.Users.FirstOrDefaultAsync(filter);
            return user;
        }

        public async Task CreateUser(User user)
        {
            try
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }

        public async Task DeleteUser(User user)
        {
            try
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }
    }
}
