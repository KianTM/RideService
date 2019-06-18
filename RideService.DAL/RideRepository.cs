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
            ReportRepository reportRepository = new ReportRepository();
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
                Ride ride = new Ride(id, name, description, rideCategory);
                reportRepository.SetAllReportsForRide(ride);
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

        public Ride GetRide(int id)
        {
            string sql = $"SELECT * FROM Rides WHERE RideId={id}";
            DataTable dataTable = ExecuteQuery(sql);
            List<Ride> rides = HandleData(dataTable);

            if (rides.Count == 0)
            {
                return null;
            }

            return rides[0];
        }

        public void AddRideToDB(Ride ride)
        {
            string sql = $"INSERT INTO Rides VALUES ('{ride.Name}', '{ride.Description}', {ride.Category.Id})";
            ExecuteNonQuery(sql);
        }
    }
}
