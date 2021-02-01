using ViewModels.WeatherModels;

namespace Services
{
    public interface IWeatherService
    {
        WeatherAPIModel.Root GetWeatherByCoordinates(string baseUrl);
        WeatherForecastModel.Root GetWeatherDetails(string baseUrl);
    }
}
