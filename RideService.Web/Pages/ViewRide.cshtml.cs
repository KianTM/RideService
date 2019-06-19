using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideService.DAL;
using RideService.Entities;

namespace RideService.Web.Pages
{
    public class ViewRideModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Index { get; set; }
        public Ride Ride { get; set; }
        [BindProperty]
        public Report Report { get; set; }
        public string BreakdownsMessage { get; set; }

        public void OnGet()
        {
            InitializeData();
        }

        public void OnPost()
        {
            InitializeData();
            ReportRepository reRepo = new ReportRepository();
            Report.ReportTime = DateTime.Now;
            Report.Ride = Ride;
            reRepo.AddReportToDB(Report);
        }

        public void InitializeData()
        {
            RideRepository riRepo = new RideRepository();
            Ride = riRepo.GetRide(Index);
            int TotalBreakdowns = Ride.GetTotalBreakdowns();
            if (Ride.DaysSinceBreakdown() >= 0 && TotalBreakdowns > 0)
                BreakdownsMessage = $"{Ride.DaysSinceBreakdown()}";
            else
                BreakdownsMessage = "Aldrig";
        }
    }
}