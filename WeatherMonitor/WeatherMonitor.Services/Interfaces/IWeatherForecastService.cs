using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Dtos.Weather;

namespace WeatherMonitor.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherSearchDto> GetWeatherForecast(string city);
    }
}
