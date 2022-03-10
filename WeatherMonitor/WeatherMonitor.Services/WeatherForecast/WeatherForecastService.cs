using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Dtos.Weather;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.Dtos.Utils;

namespace WeatherMonitor.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherForecastService> _logger;

        public WeatherForecastService(HttpClient httpClient, IMapper mapper, ILogger<WeatherForecastService> logger)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<WeatherSearchDto> GetWeatherForecast(string city)
        {
            var response = await _httpClient.GetAsync($"current.json?q={city}");
            var astroResponse = await _httpClient.GetAsync($"astronomy.json?q={city}");

            try
            {
                response.EnsureSuccessStatusCode();
                astroResponse.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                var reason = !response.IsSuccessStatusCode ? response.ReasonPhrase : (!astroResponse.IsSuccessStatusCode ? astroResponse.ReasonPhrase : ex.Message);
                _logger.Log(LogLevel.Error, $"Something went wrong calling the API: {reason}");

                return null;
            }

            var astroContent = await astroResponse.Content.ReadAsStringAsync();
            var weatherAstronomy = JsonConvert.DeserializeObject<WeatherAstronomy>(astroContent);

            var content = await response.Content.ReadAsStringAsync();          
            var weatherSearch = JsonConvert.DeserializeObject<WeatherSearch>(content);

            return _mapper.Map<WeatherAstronomy, WeatherSearch, WeatherSearchDto>(weatherAstronomy, weatherSearch);   
        }
    }
}
