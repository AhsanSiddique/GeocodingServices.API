using BusinessLogic.GeoCoding;
using Common.Helper;
using Services;
using ViewModels.WeatherModels;

namespace BusinessLogic.Weather
{
    public class WeatherBLL : IWeatherBLL
    {
        private IWeatherService _weatherService;
        private IGeoCodingBLL _geoCodingBLL;
        public WeatherBLL(IWeatherService weatherService, IGeoCodingBLL geoCodingBLL)
        {
            _weatherService = weatherService;
            _geoCodingBLL = geoCodingBLL;
        }

        public string GetWeatherForecast(decimal lon, decimal lat)
        {
            string response = "";
            string requestUrl = Helper.WeatherAPIURL + lon + "," + lat;
            var result = _weatherService.GetWeatherByCoordinates(requestUrl);
            if(result != null)
            {
                if (result.properties != null)
                {
                    response = result.properties.forecast;
                }
            }
            return response;
        }        
        public WeatherForecastModel.Root GetWeatherDetails(string address)
        {
            WeatherForecastModel.Root weatherDetails = new WeatherForecastModel.Root();
            if(address != null)
            {
                var coordinates = _geoCodingBLL.GetCoordinates(address);
                if (coordinates.x != 0 && coordinates.y != 0)
                {
                    var forecastUrl = GetWeatherForecast(coordinates.y, coordinates.x);
                    weatherDetails = _weatherService.GetWeatherDetails(forecastUrl);
                }
            }
            return weatherDetails;
        }
    }
}
