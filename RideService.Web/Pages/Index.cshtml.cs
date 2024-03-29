﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RideService.Entities;
using RideService.DAL;
using RideService.Services;

namespace RideService.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Ride> AllRides { get; set; }
        public List<RideCategory> Categories { get; set; }
        public string WeatherIconSrc { get; set; }
        public double Temperature { get; set; }
        public void OnGet()
        {
            string city = "aalborg";
            OpenWeatherMapAPI owmAPI = new OpenWeatherMapAPI();
            WeatherIconSrc = owmAPI.GetIconUrl(city);
            Temperature = owmAPI.GetCurrentTemperature(city);
            CategoryRepository cr = new CategoryRepository();
            Categories = cr.GetAllCategories();
            RideRepository rr = new RideRepository();
            AllRides = rr.GetAllRides();
        }
    }
}