using Common.Helper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Text.RegularExpressions;
using ViewModels.WeatherModels;
using static ViewModels.WeatherModels.GeoCodingModel;

namespace Services.GeoCoding
{
    public class GeoCodingService : IGeoCodingService
    {
        public GeoCodingModel.Root GetGeoCoordinates(string url)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(url, Method.GET);
                var response = client.Execute<GeoCodingModel.Root>(request);
                if (response.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<GeoCodingModel.Root>(response.Content);
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
