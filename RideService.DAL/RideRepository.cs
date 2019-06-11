using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using RideService.Entities;
using RideService.DAL;

namespace RideService.DAL
{
    public class RideRepository : BaseRepository
    {
        public List<Ride> HandleData(DataTable dataTable)
        {
            CategoryRepository catRepo = new CategoryRepository();
            List<RideCategory> categories = catRepo.GetAllCategories();
            List<Ride> rides = new List<Ride>();

            foreach (DataRow row in dataTable.Rows)
            {
                int id = (int)row["RideId"];
                string name = (string)row["Name"];
                string description = (string)row["Description"];
                int rideCategoryId = (int)row["RideCategoryId"];

                RideCategory rideCategory = null;
                foreach (RideCategory category in categories)
                {
                    if (category.Id == rideCategoryId)
                    {
                        rideCategory = category;
                        break;
                    }
                }

                List<Report> reports = new List<Report>();

                Ride ride = new Ride(id, name, description, rideCategory, reports);
                rides.Add(ride);
            }

            return rides;
        }

        public List<Ride> GetAllRides()
        {
            string sql = "SELECT * FROM Rides";
            DataTable dataTable = ExecuteQuery(sql);
            return HandleData(dataTable);
        }
    }
}
