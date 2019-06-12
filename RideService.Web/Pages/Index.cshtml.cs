using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideService.Entities;
using RideService.DAL;

namespace RideService.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Ride> AllRides { get; set; }
        public void OnGet()
        {
            RideRepository rr = new RideRepository();
            AllRides = rr.GetAllRides();
        }
    }
}