using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using AutoMapper;

namespace JijaShop.Api.Configurations.AutoMapper.Mappings
{
	public class ProductDetailsMap : Profile
	{
		public ProductDetailsMap()
		{
			CreateMap<ProductDetails, ProductDetailsDto>().ReverseMap();
		}
	}
}
