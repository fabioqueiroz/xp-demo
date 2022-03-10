using Newtonsoft.Json;
using System;

namespace WeatherMonitor.Dtos.Weather
{
    public class WeatherSearch
    {
        [JsonProperty("location")]
        public WeatherLocation Location { get; set; }
        [JsonProperty("current")]
        public WeatherCurrent Current { get; set; }
    } 
}
