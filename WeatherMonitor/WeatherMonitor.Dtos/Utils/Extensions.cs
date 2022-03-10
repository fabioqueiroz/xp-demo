using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitor.Dtos.Utils
{
    public static class Extensions
    {
        public static TDestination Map<TSource1, TSource2, TDestination>(this IMapper mapper, TSource1 source1, TSource2 source2)
        {
            var destination = mapper.Map<TSource1, TDestination>(source1);
            return mapper.Map(source2, destination);
        }
    }
}
