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
        [BindProperty(SupportsGet = true)]
        public string NameQuery {get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public int StatusQuery { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CategoryQuery { get; set; }
        public List<Ride> FilteredRides { get; set; } = new List<Ride>();

        public void OnGet()
        {
            if (NameQuery == null)
            {
                NameQuery = "";
            }
            RideRepository riRepo = new RideRepository();
            List<Ride> rides = riRepo.GetAllRides();
            foreach (Ride ride in rides)
            {
                //if (NameQuery == "")
                //{
                //    if (ride.Category.Id == CategoryQuery)
                //    {
                //        if ((int)ride.Status == StatusQuery)
                //        {
                //            FilteredRides.Add(ride);
                //            break;
                //        }
                //    }
                //}
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