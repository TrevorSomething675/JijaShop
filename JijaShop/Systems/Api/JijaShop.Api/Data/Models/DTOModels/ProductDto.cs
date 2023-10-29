namespace JijaShop.Api.Data.Models.DTOModels
{
    public class ProductDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }

		public ProductImageDto ProductImageDto { get; set; } = new ProductImageDto();
        public ProductOffersDto ProductOffersDto { get; set; } = new ProductOffersDto();
        public ProductDetailsDto ProductDetailsDto { get; set; } = new ProductDetailsDto();
    }
}
