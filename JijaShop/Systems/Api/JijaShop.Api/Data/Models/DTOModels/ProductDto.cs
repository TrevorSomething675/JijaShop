namespace JijaShop.Api.Data.Models.DTOModels
{
    public class ProductDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public ProductDetailsDto ProductDetailsDto { get; set; }
        public ProductOffersDto ProductOffersDto { get; set; }
    }
}
