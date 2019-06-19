using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using RideService.Entities;

namespace RideService.DAL
{
    public class ReportRepository : BaseRepository
    {
        public List<Report> HandleData(DataTable dataTable)
        {
            List<Report> reports = new List<Report>();

            foreach (DataRow row in dataTable.Rows)
            {
                int id = (int)row["ReportId"];
                Status status = (Status)row["Status"];
                DateTime reportTime = (DateTime)row["ReportTime"];
                string notes = (string)row["Notes"];

                Report report = new Report(id, status, reportTime, notes);
                reports.Add(report);
            }
            return reports;
        }

        public void SetAllReportsForRide(Ride ride)
        {
            string sql = $"SELECT * FROM Reports WHERE RideId={ride.Id}";
            DataTable dataTable = ExecuteQuery(sql);
            List<Report> reports = HandleData(dataTable);
            foreach (Report report in reports)
            {
                ride.AddReport(report);
            }
        }

        public void AddReportToDB(Report report)
        {
            string sql = $"INSERT INTO Reports VALUES ({(int)report.Status}, '{report.ReportTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{report.Notes}', {report.Ride.Id})";
            ExecuteNonQuery(sql);
        }
    }
}
