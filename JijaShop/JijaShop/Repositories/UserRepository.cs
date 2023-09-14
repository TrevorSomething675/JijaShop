using JijaShop.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;
using Npgsql.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;

namespace JijaShop.Repositories
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

        public async Task<User> GetUser(Expression<Func<User, bool>> filter)
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
