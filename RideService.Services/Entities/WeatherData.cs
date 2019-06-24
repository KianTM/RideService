using System;
using System.Collections.Generic;
using System.Text;

namespace RideService.Services.Entities
{
    public class WeatherData
    {
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
    }
}
