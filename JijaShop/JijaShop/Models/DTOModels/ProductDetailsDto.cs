namespace JijaShop.Models.DTOModels
{
    public class ProductDetailsDto : BaseDtoEntity
    {
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; } = 0;
        public string? Description { get; set; }
    }
}
