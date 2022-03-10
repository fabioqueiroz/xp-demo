using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Contrib.HttpClient;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherMonitor.Dtos.Weather;
using WeatherMonitor.Services.Interfaces;
using WeatherMonitor.Services.Tests.Stubs;
using WeatherMonitor.Services.WeatherForecast;
using Xunit;

namespace WeatherMonitor.Services.Tests
{
    public class WeatherForecastControllerTests
    {
        private readonly string _mockCurrentUrl = "http://localhost:1234/current.json?q=";
        private readonly string _mockAstronomyUrl = "http://localhost:1234/astronomy.json?q=";

        [Fact]
        public async Task GivenTheCityName_IsProvided_TheCurrentSearchIsSucessful()
        {
            // arrange
            var city = "Oslo";
            var handler = new Mock<HttpMessageHandler>();
            var client = handler.CreateClient();
            var data = MockData.GetMockWeatherSearch();
            
            // act
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };

            handler.SetupAnyRequest()
                .ReturnsAsync(response);

            (await client.GetAsync($"{_mockCurrentUrl}{city}")).Should().BeSameAs(response);

            // assert
            handler.VerifyAnyRequest(Times.Once());
        }

        [Fact]
        public async Task GivenTheCityName_IsProvided_TheAstronomySearchIsSucessful()
        {
            // arrange
            var city = "Oslo";
            var handler = new Mock<HttpMessageHandler>();
            var client = handler.CreateClient();
            var data = MockData.GetMockWeatherSearch();

            // act
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };

            handler.SetupAnyRequest()
                .ReturnsAsync(response);

            (await client.GetAsync($"{_mockAstronomyUrl}{city}")).Should().BeSameAs(response);

            // assert
            handler.VerifyAnyRequest(Times.Once());
        }

        [Fact]
        public async Task GivenTheCityName_DoesNotExist_TheSearchIsNotSucessful()
        {
            // arrange
            var city = "abcdefg";
            var handler = new Mock<HttpMessageHandler>();
            var client = handler.CreateClient();

            // act
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject("No matching location found.")),
                StatusCode = HttpStatusCode.BadRequest
            };

            handler.SetupAnyRequest()
                .ReturnsAsync(response);

            (await client.GetAsync($"{_mockCurrentUrl}{city}")).Should().BeSameAs(response);
            (await client.GetAsync($"{_mockAstronomyUrl}{city}")).Should().BeSameAs(response);

            // assert
            handler.VerifyAnyRequest(Times.Exactly(2));
        }
    }
}
