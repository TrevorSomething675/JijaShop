namespace JijaShop.Models.DTOModels
{
    public class ProductDetailsDto : BaseDtoEntity
    {
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
