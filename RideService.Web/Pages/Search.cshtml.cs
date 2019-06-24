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
    public class SearchModel : PageModel
    {
        public SearchModel()
        {
            CategoryRepository cr = new CategoryRepository();
            Categories = cr.GetAllCategories();
            RideRepository rr = new RideRepository();
            Rides = rr.GetAllRides();
        }
        public List<RideCategory> Categories { get; set; }
        public List<Ride> Rides { get; set; }
        [BindProperty]
        public string NameQuery { get; set; } = "";
        [BindProperty]
        public int StatusQuery { get; set; }
        [BindProperty]
        public int CategoryQuery { get; set; }
        [BindProperty]
        public DateTime DateQuery { get; set; }
        public List<Ride> FilteredRides { get; set; } = new List<Ride>();
        public string Handler { get; set; }

        public void OnPostRideSearch()
        {
            Handler = "RideSearch";
            if (NameQuery == null)
            {
                NameQuery = "";
            }
            foreach (Ride ride in Rides)
            {
                if (ride.Name.ToLower().Contains(NameQuery.ToLower()))
                {
                    if (ride.Category.Id == CategoryQuery)
                    {
                        if ((int)ride.Status == StatusQuery)
                        {
                            FilteredRides.Add(ride);
                        }
                    }
                }
            }
        }
    }
}