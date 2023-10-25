using Microsoft.AspNetCore.Identity;
using JijaShop.Extentions;

namespace JijaShop.Api.Data.Models.AuthEntities
{
    public class User : IdentityUser<int>
    {
        public int? UserAge { get; set; }
        public string? UserPhone { get; set; }
        public UserRole? Role { get; set; } = null!;
        public byte[] UserPasswordHash { get; set; } = null!;
        public byte[] UserPasswordSalt { get; set; } = null!;
    }
}
