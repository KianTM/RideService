using System;
using System.Collections.Generic;
using System.Text;

namespace RideService.Entities
{
    class Ride
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public RideCategory Category { get; }
        public List<Report> Reports { get; set; }
    }
}
