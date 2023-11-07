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
            #region Product => ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(prodDto => prodDto.ProductDetails, opt =>
                    opt.MapFrom(prod => new ProductDetails
                    {
                        Price = prod.ProductDetails.Price,
                        OldPrice = prod.ProductDetails.OldPrice,
                        Description = prod.ProductDetails.Description
                    }))
                .ForMember(prodDto => prodDto.ProductOffers, opt =>
                    opt.MapFrom(prod => new ProductOffers
                    {
                        IsHitOffer = prod.ProductOffers.IsHitOffer,
                        IsNewOffer = prod.ProductOffers.IsNewOffer
                    }))
                .ForMember(prodDto => prodDto.ProductImage, opt =>
                    opt.MapFrom(prod => new ProductImage
                    {
                        ImageName = prod.ProductImage.ImageName,
                        ImagePath = prod.ProductImage.ImagePath,
                    }));
            #endregion

            #region ProductDto => Product
            CreateMap<ProductDto, Product>()
                .ForMember(prod => prod.ProductDetails, opt =>
                    opt.MapFrom(prodDto => new ProductDetailsDto
                    {
                        Price = prodDto.ProductDetails.Price,
                        OldPrice = prodDto.ProductDetails.OldPrice,
                        Description = prodDto.ProductDetails.Description
                    }))
                .ForMember(prod => prod.ProductOffers, opt =>
                    opt.MapFrom(prodDto => new ProductOffersDto
                    {
                        IsHitOffer = prodDto.ProductOffers.IsHitOffer,
                        IsNewOffer = prodDto.ProductOffers.IsNewOffer
                    }))
                .ForMember(prod => prod.ProductImage, opt =>
                    opt.MapFrom(prodDto => new ProductImageDto
                    {
                        ImageName = prodDto.ProductImage.ImageName,
                        ImagePath = prodDto.ProductImage.ImagePath
                    }));
            #endregion

            #region ProductDto => FavoriteProduct
            CreateMap<FavoriteProduct, ProductDto>()
                .ForMember(prod => prod.ProductDetails, opt =>
                    opt.MapFrom(prodDto => new ProductDetails
                    {
                        Price = prodDto.ProductDetails.Price,
                        OldPrice = prodDto.ProductDetails.OldPrice,
                        Description = prodDto.ProductDetails.Description
                    }))
                .ForMember(prod => prod.ProductOffers, opt =>
                    opt.MapFrom(prodDto => new ProductOffers
                    {
                        IsHitOffer = prodDto.ProductOffers.IsHitOffer,
                        IsNewOffer = prodDto.ProductOffers.IsNewOffer
                    }))
                .ForMember(prod => prod.ProductImage, opt =>
                    opt.MapFrom(prodDto => new ProductImageDto
                    {
                        ImageName = prodDto.ProductImage.ImageName,
                        ImagePath = prodDto.ProductImage.ImagePath
                    }));
            #endregion

            #region FavoriteProduct => ProductDto
            CreateMap<ProductDto, FavoriteProduct>()
                .ForMember(prod => prod.ProductDetails, opt =>
                    opt.MapFrom(prodDto => new ProductDetailsDto
                    {
                        Price = prodDto.ProductDetails.Price,
                        OldPrice = prodDto.ProductDetails.OldPrice,
                        Description = prodDto.ProductDetails.Description
                    }))
                .ForMember(prod => prod.ProductOffers, opt =>
                    opt.MapFrom(prodDto => new ProductOffersDto
                    {
                        IsHitOffer = prodDto.ProductOffers.IsHitOffer,
                        IsNewOffer = prodDto.ProductOffers.IsNewOffer
                    }))
                .ForMember(prod => prod.ProductImage, opt =>
                    opt.MapFrom(prodDto => new ProductImageDto
                    {
                        ImageName = prodDto.ProductImage.ImageName,
                        ImagePath = prodDto.ProductImage.ImagePath
                    }));
            #endregion

            CreateMap<User, UserDto>()
                .ForMember(user => user.UserEmail, opt =>
                {
                    opt.MapFrom(user => user.Email);
                }).ReverseMap();

            CreateMap<FavoriteProduct, ProductDto>().ReverseMap();
            CreateMap<ProductDetails, ProductDetailsDto>().ReverseMap();
            CreateMap<ProductOffers, ProductOffersDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>()
                .ForMember(dest => dest.Image, opt => opt.Ignore()).ReverseMap();
        }
    }
}