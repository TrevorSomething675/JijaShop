using JijaShop.Api.Data.Models.AuthDtoModels;
using JijaShop.Api.Data.Models.AuthEntities;
using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;
using AutoMapper;

namespace JijaShop.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(prodDto => prodDto.ProductDetailsDto, opt =>
                    opt.MapFrom(prod => new ProductDetails
                    {
                        Price = prod.ProductDetails.Price,
                        OldPrice = prod.ProductDetails.OldPrice,
                        Description = prod.ProductDetails.Description
                    }))
                .ForMember(prodDto => prodDto.ProductOffersDto, opt =>
                    opt.MapFrom(prod => new ProductOffers
                    {
                        IsHitOffer = prod.ProductOffers.IsHitOffer,
                        IsNewOffer = prod.ProductOffers.IsNewOffer
                    }))
                .ForMember(prodDto => prodDto.ProductImageDto, opt =>
                    opt.MapFrom(prod => new ProductImage
                    {
                        ImageName = prod.ProductImage.ImageName,
                        ImagePath = prod.ProductImage.ImagePath,
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
                    }))
                .ForMember(prod => prod.ProductImage, opt =>
                    opt.MapFrom(prodDto => new ProductImageDto
                    {
                        ImageNameDto = prodDto.ProductImageDto.ImageNameDto,
                        ImagePathDto = prodDto.ProductImageDto.ImagePathDto,
                    }));

            CreateMap<User, UserDto>()
                .ForMember(user => user.UserEmail, opt =>
                {
                    opt.MapFrom(user => user.Email);
                }).ReverseMap();

            CreateMap<ProductDetails, ProductDetailsDto>().ReverseMap();
            CreateMap<ProductOffers, ProductOffersDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
        }
    }
}