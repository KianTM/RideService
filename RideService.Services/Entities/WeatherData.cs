using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace RideService.Services.Entities
{
    internal class WeatherData
    {
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
    }
}
