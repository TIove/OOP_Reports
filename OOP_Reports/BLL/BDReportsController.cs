using System;
using System.Collections.Generic;
using System.Linq;
using OOP_Reports.DAL;
using OOP_Reports.DataBases;
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

        public static List<Report> GetAllDailyReportsEmployeeId(Guid id) {
            return AccessBDReports.GetAllReportsOfEmployee(id);
        }
        
        public static void CreateSprintReportEmployee(Report report)
        {
            if (BDStaffController.GetEmployee(report.Owner).IsTeamLead)
                report.Mode = ModeReport.TeamLeadSprint;
            else
                report.Mode = ModeReport.EmployeeSprint;
            AccessBDReports.AddReport(report);
        }

        public static List<Task> GetAllResolvedTasks(Guid id) 
        {
            List<Report> reports = new List<Report>();
            reports.AddRange(AccessBDReports.GetAllReportsOfEmployee(id));
            reports.AddRange(AccessBDReports.GetAllReportsOfUnderlings(id));
            return reports.SelectMany(rep => rep.SolvedTasks).ToList();
        }
    }
}