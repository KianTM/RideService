using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using RideService.Entities;

namespace RideService.DAL
{
    class ReportRepository : BaseRepository
    {
        public List<Report> HandleData(DataTable dataTable)
        {
            RideRepository rideRepo = new RideRepository();
            List<Ride> rides = rideRepo.GetAllRides();
            List<Report> reports = new List<Report>();

            foreach (DataRow row in dataTable.Rows)
            {
                int id = (int)row["ReportId"];
                int status = (int)row["Status"];
                DateTime reportTime = (DateTime)row["ReportTime"];
                string notes = (string)row["Notes"];
                int rideId = (int)row["RideId"];

                Ride ride = null;
                foreach (Ride r in rides)
                {
                    if (r.Id == rideId)
                    {
                        ride = r;
                        break;
                    }
                }

                Status s = new Status();
                switch (status)
                {
                    case 1:
                        s = Status.Working;
                        break;
                    case 2:
                        s = Status.BeingRepaired;
                        break;
                    case 3:
                        s = Status.Broken;
                        break;
                }

                Report report = new Report(id, s, reportTime, notes, ride);
                reports.Add(report);
            }
            return reports;
        }

        public List<Report> GetAllReports()
        {
            string sql = "SELECT * FROM Reports";
            DataTable dataTable = ExecuteQuery(sql);
            return HandleData(dataTable);
        }
    }
}
