using Microsoft.AspNetCore.Identity;

namespace JijaShop.Api.Repositories.Abstractions
{
    public interface IRolesRepository
    {
        public Task<IdentityRole<int>> GetRole(int id);
    }
}
