using Newtonsoft.Json;
using RestSharp;
using System;
using ViewModels.WeatherModels;

namespace Services.Weather
{
    public class WeatherService : IWeatherService
    {
        
        public WeatherAPIModel.Root GetWeatherByCoordinates(string baseUrl)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(baseUrl, Method.GET);
                var response = client.Execute<WeatherAPIModel.Root>(request);
                if (response.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<WeatherAPIModel.Root>(response.Content);
                    return result;
                }
                else
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WeatherForecastModel.Root GetWeatherDetails(string baseUrl)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(baseUrl, Method.GET);
                var response = client.Execute<WeatherForecastModel.Root>(request);
                if (response.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<WeatherForecastModel.Root>(response.Content);
                    return result;
                }
                else
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
