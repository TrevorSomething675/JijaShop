using Microsoft.AspNetCore.Identity;

namespace JijaShop.Api.Data.Models.AuthEntities
{
    public class User : IdentityUser<int>
    {
        public int? UserAge { get; set; }
        public string? UserPhone { get; set; }
        public string? AccessToken { get; set; }
    }
}
