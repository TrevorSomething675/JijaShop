using JijaShop.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;
using Npgsql.Internal;

namespace JijaShop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        public UserRepository(MainContext context, IMapper mapper, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<User> GetUser(int id)
        {
            var resultUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            return resultUser;
        }

        public async Task CreateUser(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _context.Add(user);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }

        public async Task DeleteUser(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _context.Remove(user);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }

        public async Task UpdateUser(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
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
