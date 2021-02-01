using BusinessLogic.Weather;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ViewModels.WeatherModels;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherBLL _weatherBLL;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherBLL weatherBLL)
        {
            _logger = logger;
            _weatherBLL = weatherBLL;
        }

        [HttpGet("{SearchTerm}")]
        [AllowAnonymous]
        public IEnumerable<WeatherForecastModel.Period> Get(string SearchTerm)
        {
            var forecast = new List<WeatherForecastModel.Period>();
            var response = _weatherBLL.GetWeatherDetails(SearchTerm);
            if (response != null)
            {
                if (response.properties != null)
                {
                    forecast = response.properties.periods;
                }
            }
            return forecast;
        }
    }
}
