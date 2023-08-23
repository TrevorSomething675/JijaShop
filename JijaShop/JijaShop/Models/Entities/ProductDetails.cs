namespace JijaShop.Models.Entities
{
    public class ProductDetails : BaseEntity
    {
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}