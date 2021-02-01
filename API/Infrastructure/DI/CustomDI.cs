using BusinessLogic.GeoCoding;
using BusinessLogic.Weather;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.GeoCoding;
using Services.Weather;

namespace API.Infrastructure.DI
{
    public static class CustomDI
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherBLL, WeatherBLL>();

            services.AddScoped<IGeoCodingService, GeoCodingService>();
            services.AddScoped<IGeoCodingBLL, GeoCodingBLL>();
        }
    }
}
