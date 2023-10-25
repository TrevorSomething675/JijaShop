using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using AutoMapper;
using JijaShop.Api.Data.Models.AuthEntities;
using JijaShop.Api.Data.Models.AuthDtoModels;

namespace JijaShop.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(prodDto => prodDto.ProductDetailsDto, opt =>
                    opt.MapFrom(prod => new ProductDetailsDto
                    {
                        Price = prod.ProductDetails.Price,
                        OldPrice = prod.ProductDetails.OldPrice,
                        Description = prod.ProductDetails.Description
                    }))
                .ForMember(prodDto => prodDto.ProductOffersDto, opt =>
                    opt.MapFrom(prod => new ProductOffersDto
                    {
                        IsHitOffer = prod.ProductOffers.IsHitOffer,
                        IsNewOffer = prod.ProductOffers.IsNewOffer
                    }));

            CreateMap<ProductDto, Product>()
                .ForMember(prod => prod.ProductDetails, opt =>
                    opt.MapFrom(prodDto => new ProductDetailsDto
                    {
                        Price = prodDto.ProductDetailsDto.Price,
                        OldPrice = prodDto.ProductDetailsDto.OldPrice,
                        Description = prodDto.ProductDetailsDto.Description
                    }))
                .ForMember(prod => prod.ProductOffers, opt =>
                    opt.MapFrom(prodDto => new ProductOffersDto
                    {
                        IsHitOffer = prodDto.ProductOffersDto.IsHitOffer,
                        IsNewOffer = prodDto.ProductOffersDto.IsNewOffer
                    }));

            CreateMap<ProductDetails, ProductDetailsDto>().ReverseMap();
            CreateMap<ProductOffers, ProductOffersDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
