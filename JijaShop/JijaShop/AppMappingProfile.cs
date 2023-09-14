using JijaShop.Models.DTOModels;
using JijaShop.Models.Entities;
using AutoMapper;

namespace JijaShop
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(prodDto => prodDto.ProductDetailsDto, opt =>
                    opt.MapFrom(prod => new ProductDetailsDto
                    {
                        Price = prod.ProductDetails.Price,
                        Description = prod.ProductDetails.Description,
                    }));

            CreateMap<ProductDto, Product>()
                .ForMember(prod => prod.ProductDetails, opt =>
                    opt.MapFrom(prodDto => new ProductDetailsDto
                    {
                        Price = prodDto.ProductDetailsDto.Price,
                        Description = prodDto.ProductDetailsDto.Description,
                    }));

            CreateMap<ProductDetails, ProductDetailsDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<User, LoginDto>().ReverseMap();
        }
    }
}
