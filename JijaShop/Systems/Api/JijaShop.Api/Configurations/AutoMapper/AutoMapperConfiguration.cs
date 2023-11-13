using JijaShop.Api.Configurations.AutoMapper.Mappings;
using AutoMapper;
using static Org.BouncyCastle.Math.EC.ECCurve;

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
                config.AddProfile<ProductImageMap>();
                config.AddProfile<ProductOffersMap>();
                config.AddProfile<ProductDetailsMap>();
            });

			return services;
        }

        public static MapperConfiguration CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<ProductMap>();
                config.AddProfile<ProductImageMap>();
                config.AddProfile<ProductOffersMap>();
                config.AddProfile<ProductDetailsMap>();
            });
            mapperConfiguration.AssertConfigurationIsValid();

            return mapperConfiguration;
		}
	}
}