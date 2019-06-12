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
        public string BreakdownsMessage { get; set; }

        public void OnGet()
        {
            RideRepository riRepo = new RideRepository();
            ViewData["index"] = Index;
            Ride = riRepo.GetRide(Index);
            if (Ride.DaysSinceBreakdown() == 0)
            {
                BreakdownsMessage = "Denne forlystelse har aldrig brudt ned.";
            }
            else
            {
                BreakdownsMessage = $"{Ride.DaysSinceBreakdown()}";
            }
        }
    }
}