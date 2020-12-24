using System;
using System.Collections.Generic;
using System.Linq;
using OOP_Reports.DAL;
using OOP_Reports.Entities.Report;
using OOP_Reports.Entities.Task;

namespace OOP_Reports.BLL
{
    public class BDReportsController
    {
        public static void CreateDailyReport(Report report)
        {
            report.Mode = ModeReport.Daily;
            AccessBDReports.AddReport(report);
        }

        public static void CreateSprintReportEmployee(Report report)
        {
            report.Mode = ModeReport.EmployeeSprint;
            AccessBDReports.AddReport(report);
        }

        public static List<Task> GetAllResolvedTasks(Guid id)
        {
            var reports = AccessBDReports.GetAllReportsOfEmployee(id);
            return reports.SelectMany(rep => rep.SolvedTasks).ToList();
        }
    }
}