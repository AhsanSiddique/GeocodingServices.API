using BusinessLogic.Weather;
using Common.Helper;
using Services;
using static ViewModels.WeatherModels.GeoCodingModel;

namespace BusinessLogic.GeoCoding
{
    public class GeoCodingBLL : IGeoCodingBLL
    {
        private IGeoCodingService _geocodingService;
        public GeoCodingBLL(IGeoCodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }
        public Coordinates GetCoordinates(string address)
        {
            Coordinates coordinates = new Coordinates();
            string Url =  Helper.GeoCodingURLGenerator(address);
            var result = _geocodingService.GetGeoCoordinates(Url);
            if(result != null)
            {
                if (result.result != null)
                {
                    if (result.result.addressMatches.Count > 0)
                    {
                        if (result.result.addressMatches[0].coordinates != null)
                        {
                            coordinates.x = result.result.addressMatches[0].coordinates.x;
                            coordinates.y = result.result.addressMatches[0].coordinates.y;
                        }
                    }
                }
            }
            return coordinates;
        }
    }
}
