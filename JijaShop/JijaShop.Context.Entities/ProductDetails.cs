namespace JijaShop.Context.Entities
{
    public class ProductDetails : BaseEntity
    {
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; } = 0;
        public string? Description { get; set; }
    }
}
