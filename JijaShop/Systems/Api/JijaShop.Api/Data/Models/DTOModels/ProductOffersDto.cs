namespace JijaShop.Api.Data.Models.DTOModels
{
    public class ProductOffersDto : BaseEntityDto
    {
        public bool IsHitOffer { get; set; } = false;
        public bool IsNewOffer { get; set; } = false;
    }
}
