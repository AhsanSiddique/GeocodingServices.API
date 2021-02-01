using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.WeatherModels;

namespace BusinessLogic.Weather
{
    public interface IWeatherBLL
    {
        string GetWeatherForecast(decimal lon, decimal lat);
        WeatherForecastModel.Root GetWeatherDetails(string address);
    }
}
