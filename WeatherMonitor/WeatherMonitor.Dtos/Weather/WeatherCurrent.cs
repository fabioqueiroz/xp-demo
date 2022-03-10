using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Dtos.Weather
{
    public class WeatherCurrent
    {
        [JsonProperty("temp_c")]
        public decimal TemperatureC { get; set; }
        [JsonProperty("temp_f")]
        public decimal TemperatureF { get; set; }
    }
}
