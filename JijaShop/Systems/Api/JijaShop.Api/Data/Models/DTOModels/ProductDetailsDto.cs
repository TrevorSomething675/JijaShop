namespace JijaShop.Api.Data.Models.DTOModels
{
    public class ProductDetailsDto : BaseEntityDto
    {
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; } = 0;
        public string? Description { get; set; }
    }
}
