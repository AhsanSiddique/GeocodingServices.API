using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.WeatherModels;
using static ViewModels.WeatherModels.GeoCodingModel;

namespace Services
{
    public interface IGeoCodingService
    {
        GeoCodingModel.Root GetGeoCoordinates(string url);
    }
}
