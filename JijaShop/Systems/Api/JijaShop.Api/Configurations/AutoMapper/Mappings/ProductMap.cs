using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using AutoMapper;

namespace JijaShop.Api.Configurations.AutoMapper.Mappings
{
	public class ProductMap : Profile
	{
		public ProductMap()
		{
			CreateMap<Product, ProductDto>()
				.ForMember(prodDto => prodDto.ProductDetails, opt =>
					opt.MapFrom(prodDetailsDto => prodDetailsDto.ProductDetails))
				.ForMember(prodDto => prodDto.ProductOffers, opt =>
					opt.MapFrom(prodDtoOffers => prodDtoOffers.ProductOffers))
				.ForMember(prodDto => prodDto.ProductImage, opt =>
					opt.MapFrom(prodImageDto => prodImageDto.ProductImage)).ReverseMap();

			CreateMap<ProductDto, Product>()
				.ForMember(prod => prod.Id, opt =>
					opt.Ignore())
				.ForMember(prod => prod.ProductImageId, opt =>
					opt.Ignore())
				.ForMember(prod => prod.ProductOffersId, opt =>
					opt.Ignore())
				.ForMember(prod => prod.ProductDetailsId, opt =>
					opt.Ignore())
				.ForMember(prod => prod.CreatedDate, opt =>
					opt.Ignore())
				.ForMember(prod => prod.UpdateDate, opt =>
					opt.Ignore()).ReverseMap();
		}
	}
}
