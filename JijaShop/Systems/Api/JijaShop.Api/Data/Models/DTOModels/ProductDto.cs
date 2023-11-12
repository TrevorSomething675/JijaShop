namespace JijaShop.Api.Data.Models.DTOModels
{
    public class ProductDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }

		public ProductImageDto ProductImage { get; set; } = new ProductImageDto();
        public ProductOffersDto ProductOffers { get; set; } = new ProductOffersDto();
        public ProductDetailsDto ProductDetails { get; set; } = new ProductDetailsDto();

		public bool IsFavorite { get; set; } = false;
	}
}
