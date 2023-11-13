using JijaShop.Api.Configurations.AutoMapper.Mappings;
using AutoMapper;

namespace JijaShop.Api.Configurations.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; set; } = null!;

        public static IServiceCollection AddAppAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<ProductMap>();
                config.AddProfile<CartProductMap>();
                config.AddProfile<FavoriteProductMap>();

                config.AddProfile<ProductImageMap>();
                config.AddProfile<ProductOffersMap>();
                config.AddProfile<ProductDetailsMap>();
            });

			return services;
        }
	}
}