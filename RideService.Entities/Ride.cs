﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RideService.Entities
{
    public class Ride
    {
        private List<Report> reports = new List<Report>();
        public Ride()
        {
        }

        public Ride(int id, string name, string description, RideCategory category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status {
            get
            {
                if (ReportsOrdered.Count == 0)
                {
                    return Status.Working;
                }
                else
                {
                    return ReportsOrdered[0].Status;
                }
            }
        }
        public RideCategory Category { get; }
        public IReadOnlyList<Report> ReportsOrdered { 
            get
            {
                return reports.OrderByDescending(r => r.DateTime).ToList().AsReadOnly();
            }
        }

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

        public void AddReport(Report report)
        {
            report.Ride = this;
            reports.Add(report);
        }

        public int GetTotalBreakdowns()
        {
            int breakdowns = 0;
            foreach(Report r in ReportsOrdered)
            {
                if (r.Status == Status.Broken)
                {
                    breakdowns++;
                }
            }
            return breakdowns;
        }
    }
}