using Serilog;

namespace JijaShop.Api.Configurations
{
    public static class LoggerConfiguration
    {
        public static void AddAppLogger(this WebApplicationBuilder builder)
        {
            var logger = new Serilog.LoggerConfiguration().ReadFrom
                .Configuration(builder.Configuration).CreateLogger();

            builder.Host.UseSerilog(logger, true);
        }
    }
}
