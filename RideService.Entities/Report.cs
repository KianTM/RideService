using System;
using System.Collections.Generic;
using System.Text;

namespace RideService.Entities
{
    class Report
    {
        public int Id { get; set; }
        public Ride Ride { get; set; }
        public DateTime DateTime { get; set; }
        public string Notes { get; set; }
    }
}
