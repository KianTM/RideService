using System;
using System.Collections.Generic;
using System.Text;

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
                    throw new NotImplementedException();
                }
            }
        }
        public RideCategory Category { get; }
        public List<Report> Reports { get; set; }

        public string GetShortDescription()
        {
            return Description.Remove(50);
        }
    }
}
