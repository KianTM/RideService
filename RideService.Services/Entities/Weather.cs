using System;
using System.Collections.Generic;
using System.Text;

namespace RideService.Services.Entities
{
    public class Weather
    {
        public string Icon { get; set; }

        public override string ToString()
        {
            return Icon;
        }
    }
}
