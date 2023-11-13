using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using AutoMapper;

namespace JijaShop.Api.Configurations.AutoMapper.Mappings
{
	public class ProductImageMap : Profile
	{
		public ProductImageMap() 
		{
			CreateMap<ProductImage, ProductImageDto>()
				.ForMember(prodImage => prodImage.Image, opt =>
					opt.Ignore()).ReverseMap();
			//CreateMap<ProductImageDto, ProductImage>()
			//	.ForMember(prodImageDto => prodImageDto.Id, opt =>
			//		opt.Ignore());
		}
	}
}
