using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using AutoMapper;

namespace JijaShop.Api.Configurations.AutoMapper.Mappings
{
	public class FavoriteProductMap : Profile
	{
		public FavoriteProductMap()
		{
			CreateMap<FavoriteProduct, ProductDto>()
				.ForMember(prodDto => prodDto.ProductDetails, opt =>
					opt.MapFrom(favorProdDto => favorProdDto.ProductDetails))
				.ForMember(prodDto => prodDto.ProductOffers, opt =>
					opt.MapFrom(favorProdDto => favorProdDto.ProductOffers))
				.ForMember(prodDto => prodDto.ProductImage, opt =>
					opt.MapFrom(favorProdDto => favorProdDto.ProductImage))
				.ReverseMap();

			CreateMap<ProductDto, FavoriteProduct>()
				.ForMember(favorProdDto => favorProdDto.Id, opt =>
					opt.Ignore())
				.ForMember(favorProdDto => favorProdDto.ProductImageId, opt =>
					opt.Ignore())
				.ForMember(favorProdDto => favorProdDto.ProductOffersId, opt =>
					opt.Ignore())
				.ForMember(favorProdDto => favorProdDto.ProductDetailsId, opt =>
					opt.Ignore())
				.ForMember(favorProdDto => favorProdDto.CreatedDate, opt =>
					opt.Ignore())
				.ForMember(favorProdDto => favorProdDto.UpdateDate, opt =>
					opt.Ignore()).ReverseMap();
		}
	}
}
