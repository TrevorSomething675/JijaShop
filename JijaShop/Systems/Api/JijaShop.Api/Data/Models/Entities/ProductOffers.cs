﻿namespace JijaShop.Api.Data.Models.Entities
{
    public class ProductOffers : BaseEntity
    {
        public bool IsHitOffer { get; set; } = false;
        public bool IsNewOffer { get; set; } = false;
    }
}
