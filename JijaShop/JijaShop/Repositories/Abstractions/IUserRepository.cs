using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Repositories.Abstractions
{
    public interface IUserRepository
    {
        public Task DeleteUser(UserDto userDto);
        public Task UpdateUser(UserDto userDto);
        public Task CreateUser(UserDto userDto);
        public Task<User> GetUser(Expression<Func<User, bool>> filter);
    }
}
