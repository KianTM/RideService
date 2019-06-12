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

        public Report(int id, Status status, DateTime date, string notes)
        {
            Id = id;
            Status = Status;
            ReportTime = date;
            Notes = notes;
        }

        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime ReportTime { get; set; }
        public string Notes { get; set; }
        public Ride Ride { get; set; }
    }
}
