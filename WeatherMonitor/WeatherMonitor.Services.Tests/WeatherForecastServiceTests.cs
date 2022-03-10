using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Dtos.Mappers;
using WeatherMonitor.Dtos.Weather;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.Services.Tests.Stubs;
using WeatherMonitor.Services.WeatherForecast;
using WeatherMonitor.Dtos.Utils;
using Xunit;

namespace WeatherMonitor.Services.Tests
{
    public class WeatherForecastServiceTests
    {
        private readonly IConfigurationRoot _configuration;
        private readonly ServiceProvider _serviceProvider;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastServiceTests()
        {
            var builder = new ConfigurationBuilder();
            _configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddScoped<IWeatherForecastService, WeatherForecastServiceFake>();
            services.AddLogging();
            services.AddAutoMapper(typeof(WeatherSearchMapper));

            _serviceProvider = services.BuildServiceProvider();
            _weatherForecastService = _serviceProvider.GetService<IWeatherForecastService>();
        }

        [Fact]
        public async Task GivenTheCityName_TheServiceReturns_TheWeatherData()
        {
            // arrange
            var city = "Oslo";
            var dto = MockData.GetMockSearchDtoData();

            // act
            var result = await _weatherForecastService.GetWeatherForecast(city);

            // assert
            Assert.Equal(dto.City, result.City);
        }
    }
}
