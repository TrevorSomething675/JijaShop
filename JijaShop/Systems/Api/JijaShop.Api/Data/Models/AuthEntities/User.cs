using JijaShop.Api.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace JijaShop.Api.Data.Models.AuthEntities
{
    public class User : IdentityUser<int>
    {
        public int? UserAge { get; set; }
        public string? UserPhone { get; set; }
        public string? AccessToken { get; set; }

        //public int CartProductsId { get; set; }
        //public List<CartProduct> CartProducts { get; set; }

        //public int FavoriteProductsId { get; set; }
        //public List<FavoriteProduct> FavoriteProducts { get; set; }
    }
}