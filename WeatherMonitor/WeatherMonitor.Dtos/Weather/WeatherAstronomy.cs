using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Dtos.Weather
{
    public class WeatherAstronomy
    {
        [JsonProperty("astronomy")]
        public Astronomy Astronomy { get; set; }
    }

    public class Astronomy
    {
        [JsonProperty("astro")]
        public Astro Astro { get; set; }
    }

    public class Astro
    {
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }
        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }
}
