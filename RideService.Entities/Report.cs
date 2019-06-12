using System;
using System.Collections.Generic;
using System.Text;

namespace RideService.Entities
{
    public class Report
    {
        public Report()
        {
        }

        public Report(int id, Status status, DateTime dateTime, string notes)
        {
            Id = id;
            Status = Status;
            DateTime = dateTime;
            Notes = notes;
        }

        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime DateTime { get; set; }
        public string Notes { get; set; }
        public Ride Ride { get; set; }
    }
}
