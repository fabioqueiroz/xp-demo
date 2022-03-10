using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitor.Dtos.Weather;

namespace WeatherMonitor.Dtos.Mappers
{
    public class WeatherSearchMapper : Profile
    {
        public WeatherSearchMapper()
        {
            CreateMap<WeatherSearch, WeatherSearchDto>()
                .ForMember(target => target.City, source => source.MapFrom(s => s.Location.City))
                .ForMember(target => target.Region, source => source.MapFrom(s => s.Location.Region))
                .ForMember(target => target.Country, source => source.MapFrom(s => s.Location.Country))
                .ForMember(target => target.LocalTime, source => source.MapFrom(s => s.Location.LocalTime))
                .ForMember(target => target.TemperatureC, source => source.MapFrom(s => s.Current.TemperatureC))
                .ForMember(target => target.TemperatureF, source => source.MapFrom(s => s.Current.TemperatureF));

            CreateMap<WeatherAstronomy, WeatherSearchDto>()
                .ForPath(target => target.Sunrise, source => source.MapFrom(s => s.Astronomy.Astro.Sunrise))
                .ForPath(target => target.Sunset, source => source.MapFrom(s => s.Astronomy.Astro.Sunset));
        }
    }
}
