namespace JijaShop.Models.DTOModels
{
    public class ProductDto
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public ProductDetailsDto ProductDetailsDto { get; set; }
    }
}
