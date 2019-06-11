using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RideService.Entities
{
    public class Ride
    {
        public Ride()
        {
        }

        public Ride(int id, string name, string description, RideCategory category, List<Report> reports)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Reports = reports;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status {
            get
            {
                if (Reports.Count == 0)
                {
                    return Status.Working;
                }
                else
                {
                    return Reports.LastOrDefault().Status;
                }
            }
        }
        public RideCategory Category { get; }
        public List<Report> Reports { get; set; }

        public string GetShortDescription()
        {
            return $"{Description.Remove(50)}...";
        }

        public string GetStatusAsString()
        {
            switch (Status)
            {
                case Status.Working:
                    return "Kører";
                case Status.BeingRepaired:
                    return "Under reperation...";
                case Status.Broken:
                    return "I stykker";
            }
            throw new InvalidOperationException();
        }
    }
}
