namespace JijaShop.Data.Models.DTOModels
{
    public class ProductOffersDto : BaseDtoEntity
    {
        public bool IsHitOffer { get; set; } = false;
        public bool IsNewOffer { get; set; } = false;
    }
}
