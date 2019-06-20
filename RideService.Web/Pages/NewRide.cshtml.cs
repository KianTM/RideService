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
    public class NewRideModel : PageModel
    {
        public NewRideModel()
        {
            CategoryRepository cr = new CategoryRepository();
            Categories = cr.GetAllCategories();
        }
        [BindProperty]
        public Ride Ride { get; set; }
        [BindProperty]
        public RideCategory Category { get; set; }
        [BindProperty]
        public int CategoryId { get; set; }
        public List<RideCategory> Categories { get; set; } = new List<RideCategory>();
        public string Handler { get; set; }

        public void OnGet()
        {

        }

        public void OnPostCreateRide()
        {
            Handler = "CreateRide";
            foreach (RideCategory category in Categories)
            {
                if (category.Id == CategoryId)
                {
                    Ride.Category = category;
                    break;
                }
            }
            RideRepository rr = new RideRepository();
            rr.AddRideToDB(Ride);
        }

        public void OnPostCreateCategory()
        {
            Handler = "CreateCategory";
            CategoryRepository cr = new CategoryRepository();
            cr.AddCategoryToDB(Category);
        }
    }
}