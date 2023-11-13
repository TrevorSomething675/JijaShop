using JijaShop.Api.Data.Models.Entities;
using AutoMapper;

namespace JijaShop.Api.Configurations.AutoMapper.Mappings
{
	public class CartProductMap : Profile
	{
		public CartProductMap() 
		{
			CreateMap<Product, CartProduct>().ReverseMap();

			CreateMap<CartProduct, Product>()
				.ForMember(prod => prod.Id, opt =>
					opt.Ignore())
				.ForMember(prod => prod.ProductImageId, opt =>
					opt.Ignore())
				.ForMember(prod => prod.ProductOffersId, opt =>
					opt.Ignore())
				.ForMember(prod => prod.ProductDetailsId, opt =>
					opt.Ignore()).ReverseMap();
		}
	}
}