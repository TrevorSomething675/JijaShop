namespace JijaShop.Context.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public int ProductOffersId { get; set; }
        public ProductOffers ProductOffers { get; set; }

        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}
