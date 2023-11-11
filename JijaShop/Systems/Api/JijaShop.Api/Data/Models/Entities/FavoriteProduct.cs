using JijaShop.Api.Data.Models.AuthEntities;

namespace JijaShop.Api.Data.Models.Entities
{
	public class FavoriteProduct : BaseEntity
	{
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ProductImageId { get; set; }
        public ProductImage ProductImage { get; set; } = null!;

        public int ProductOffersId { get; set; }
        public ProductOffers ProductOffers { get; set; } = null!;

        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; } = null!;
    }
}
