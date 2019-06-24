using RideService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RideService.EntitiesTest
{
    public class RideTest
    {
        [Fact]
        public void DaysSinceLastShutdown_ReturnsCorrectDaysWithOneBrokenReport()
        {
            //Arrange
            Ride ride = new Ride();
            Report report = new Report();
            report.Status = Status.Broken;
            DateTime reportTime = new DateTime(2019, 06, 10, 10, 30, 00);
            report.ReportTime = reportTime;
            int expectedDays = (DateTime.Now - reportTime).Days;
            ride.AddReport(report);

            //Action
            int actualDays = ride.DaysSinceBreakdown();

            //Assert
            Assert.Equal<int>(expectedDays, actualDays);
        }

        [Fact]
        public void DaysSinceLastShutdown_ReturnsCorrectDaysWithMultipleBrokenReports()
        {
            //Arrange
            Ride ride = new Ride();
            Report r1 = new Report();
            Report r2 = new Report();
            Report r3 = new Report();
            r1.Status = Status.Broken;
            r2.Status = Status.Broken;
            r3.Status = Status.Broken;
            DateTime rt1 = new DateTime(2019, 06, 01, 10, 30, 00);
            DateTime rt2 = new DateTime(2019, 06, 06, 10, 30, 00);
            DateTime rt3 = new DateTime(2019, 06, 11, 10, 30, 00);
            r1.ReportTime = rt1;
            r2.ReportTime = rt2;
            r3.ReportTime = rt3;
            int expectedDays = (DateTime.Now - rt3).Days;
            ride.AddReport(r1);
            ride.AddReport(r2);
            ride.AddReport(r3);

            //Action
            int actualDays = ride.DaysSinceBreakdown();

            //Assert
            Assert.Equal<int>(expectedDays, actualDays);
        }

        [Fact]
        public void DaysSinceLastShutdown_ReturnsCorrectDaysWithOneBrokenReportAndSomeWorkingAndUnderRepair()
        {
            //Arrange
            Ride ride = new Ride();
            Report rBroken = new Report();
            Report r1 = new Report();
            Report r2 = new Report();
            Report r3 = new Report();
            Report r4 = new Report();
            rBroken.Status = Status.Broken;
            r1.Status = Status.Working;
            r2.Status = Status.BeingRepaired;
            r3.Status = Status.Working;
            r4.Status = Status.BeingRepaired;
            DateTime rtBroken = new DateTime(2019, 06, 01, 10, 30, 00);
            DateTime rt1 = new DateTime(2019, 06, 10, 10, 30, 00);
            DateTime rt2 = new DateTime(2019, 06, 13, 10, 30, 00);
            DateTime rt3 = new DateTime(2019, 05, 27, 10, 30, 00);
            DateTime rt4 = new DateTime(2019, 06, 17, 10, 30, 00);
            rBroken.ReportTime = rtBroken;
            r1.ReportTime = rt1;
            r2.ReportTime = rt2;
            r3.ReportTime = rt3;
            r4.ReportTime = rt4;
            int expectedDays = (DateTime.Now - rtBroken).Days;
            ride.AddReport(rBroken);
            ride.AddReport(r1);
            ride.AddReport(r2);
            ride.AddReport(r3);
            ride.AddReport(r4);

            //Action
            int actualDays = ride.DaysSinceBreakdown();

            //Assert
            Assert.Equal<int>(expectedDays, actualDays);
        }

        [Fact]
        public void DaysSinceLastShutdown_ReturnsNegOneWithNoBrokenReports()
        {
            //Assign
            Ride ride = new Ride();
            Report report = new Report();
            report.Status = Status.Working;
            DateTime reportTime = new DateTime(2019, 06, 10, 10, 30, 00);
            report.ReportTime = reportTime;
            int expectedDays = -1;
            ride.AddReport(report);

            //Action
            int actualDays = ride.DaysSinceBreakdown();

            //Assert
            Assert.Equal<int>(expectedDays, actualDays);
        }

        [Fact]
        public void GetStatus_ReturnsWorkingWithNoReport()
        {
            //Assign
            Ride ride = new Ride();
            Status expectedStatus = Status.Working;

            //Action
            Status actualStatus = ride.Status;

            //Assert
            Assert.Equal<Status>(expectedStatus, actualStatus);
        }

        [Fact]
        public void GetStatus_ReturnsCorrectWithOneReport()
        {
            //Assign
            Ride ride = new Ride();
            Report report = new Report();
            report.Status = Status.BeingRepaired;
            Status expectedStatus = Status.BeingRepaired;
            ride.AddReport(report);

            //Action
            Status actualStatus = ride.Status;

            //Assert
            Assert.Equal<Status>(expectedStatus, actualStatus);
        }

        [Fact]
        public void GetStatus_ReturnsCorectWithMultipleReports()
        {
            //Assign
            Ride ride = new Ride();
            Report r1 = new Report();
            Report r2 = new Report();
            Report r3 = new Report();
            Report r4 = new Report();
            Report r5 = new Report();
            r1.Status = Status.Working;
            r2.Status = Status.Broken;
            r3.Status = Status.Working;
            r4.Status = Status.BeingRepaired;
            r5.Status = Status.Broken;
            DateTime rt1 = new DateTime(2019, 06, 10, 10, 30, 00);
            DateTime rt2 = new DateTime(2019, 06, 13, 10, 30, 00);
            DateTime rt3 = new DateTime(2019, 05, 27, 10, 30, 00);
            DateTime rt4 = new DateTime(2019, 06, 17, 10, 30, 00);
            DateTime rt5 = new DateTime(2019, 06, 01, 10, 30, 00);
            r1.ReportTime = rt1;
            r2.ReportTime = rt2;
            r3.ReportTime = rt3;
            r4.ReportTime = rt4;
            r5.ReportTime = rt5;
            Status expectedStatus = Status.BeingRepaired;
            ride.AddReport(r1);
            ride.AddReport(r2);
            ride.AddReport(r3);
            ride.AddReport(r4);
            ride.AddReport(r5);

            //Action
            Status actualStatus = ride.Status;

            //Assert
            Assert.Equal<Status>(expectedStatus, actualStatus);
        }
    }
}
