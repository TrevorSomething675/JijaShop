using JijaShop.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using JijaShop.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace JijaShop.Api.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly MainContext _mainContext;

        public RolesRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task<IdentityRole<int>> GetRole(int id)
        {
            var result = _mainContext.Roles.FirstOrDefault(role => role.Id == id);

            return result;
        }

        public async Task<List<IdentityRole<int>>> GetRoles()
        {
            var result = await _mainContext.Roles.ToListAsync();

            return result;
        }
    }
}
