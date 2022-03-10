using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Dtos.Weather;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.Dtos.Utils;


namespace WeatherMonitor.Services.Tests.Stubs
{
    public class WeatherForecastServiceFake : IWeatherForecastService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherForecastServiceFake> _logger;
        public WeatherForecastServiceFake(IMapper mapper, ILogger<WeatherForecastServiceFake> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<WeatherSearchDto> GetWeatherForecast(string city)
        {
            var mockWeatherSearchData = MockData.GetMockWeatherSearch();
            var mockAstronomyData = MockData.GetMockAstronomyData();
            var result = _mapper.Map<WeatherAstronomy, WeatherSearch, WeatherSearchDto>(mockAstronomyData, mockWeatherSearchData);

            return await Task.FromResult(result);
        }
    }
}
