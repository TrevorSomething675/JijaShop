using Microsoft.EntityFrameworkCore;
using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;

namespace JijaShop.Repositories
{
    public class UserRepository
    {
        private readonly MainContext _context;
        private readonly IMapper _mapper;
        public UserRepository(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> GetUser(int id)
        {
            var resultUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            return resultUser;
        }

        public async Task DeleteUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _context.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _context.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _context.Add(user);

            await _context.SaveChangesAsync();
        }
    }
}
