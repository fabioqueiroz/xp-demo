using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Dtos.Weather;

namespace WeatherMonitor.Services.Tests.Stubs
{
    public class MockData
    {
        public static WeatherSearchDto GetMockSearchDtoData()
        {
            return new WeatherSearchDto
            {
                City = "Oslo",
                Region = "Oslo",
                Country = "Norway",
                LocalTime = "2022-02-20 15:47",
                TemperatureC = 5.0M,
                TemperatureF = 41.0M,
                Sunrise = "07:42 AM",
                Sunset = "05:21 PM"
            };
        }

        public static WeatherSearch GetMockWeatherSearch()
        {
            var weatherSearch = new WeatherSearch
            {
                Location = new WeatherLocation(),
                Current = new WeatherCurrent()
            };

            weatherSearch.Location.City = "Oslo";
            weatherSearch.Location.Region = "Oslo";
            weatherSearch.Location.Country = "Norway";
            weatherSearch.Location.LocalTime = "2022-02-20 15:47";
            weatherSearch.Current.TemperatureC = 5.0M;
            weatherSearch.Current.TemperatureF = 41.0M;

            return weatherSearch;
        }

        public static WeatherAstronomy GetMockAstronomyData()
        {
            var weatherAstronomy = new WeatherAstronomy
            {
                Astronomy = new Astronomy()
            };
            weatherAstronomy.Astronomy.Astro = new Astro
            {
                Sunrise = "07:42 AM",
                Sunset = "05:21 PM"
            };

            return weatherAstronomy;
        }
    }
}
