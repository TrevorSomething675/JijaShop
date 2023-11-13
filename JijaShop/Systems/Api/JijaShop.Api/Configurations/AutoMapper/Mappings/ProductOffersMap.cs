using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using AutoMapper;

namespace JijaShop.Api.Configurations.AutoMapper.Mappings
{
	public class ProductOffersMap : Profile
	{
		public ProductOffersMap() 
		{
			CreateMap<ProductOffers, ProductOffersDto>().ReverseMap();
		}
	}
}
