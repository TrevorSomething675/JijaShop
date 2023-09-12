namespace JijaShop.Models.DTOModels
{
    public class ProductDto : BaseDtoEntity
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public ProductDetailsDto ProductDetailsDto { get; set; }
    }
}
