using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Dtos.Weather
{
    public class WeatherSearchDto
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string LocalTime { get; set; }
        public decimal TemperatureC { get; set; }
        public decimal TemperatureF { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
}
