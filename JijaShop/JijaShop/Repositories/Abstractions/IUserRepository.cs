using JijaShop.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Repositories.Abstractions
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetUser(Expression<Func<User, bool>> filter = null);
        public Task CreateUser(User userDto);
        public Task DeleteUser(User userDto);
        public Task UpdateUser(User userDto);
    }
}
