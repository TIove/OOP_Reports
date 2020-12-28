using System;
using System.Collections.Generic;
using System.Linq;
using OOP_Reports.DAL;
using OOP_Reports.DataBases;
using OOP_Reports.Entities;
using OOP_Reports.Entities.Report;
using OOP_Reports.Entities.Task;

namespace OOP_Reports.BLL
{
    public class BDReportsController
    {
        private static void CreateDailyReport(Report report)
        {
            report.Mode = ModeReport.Daily;
            AccessBDReports.AddReport(report);
        }

        public static List<Report> GetAllDailyReportsEmployeeId(Guid id) {
            return AccessBDReports.GetAllReportsOfEmployee(id);
        }
        
        private static void CreateSprintReportEmployee(Report report)
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
        
        public static void CreateDailyReport(Guid id, string description = null)
        {
            //     oldList.ForEach((item)=> { newList.Add(new SomeType(item));});
            var resolvedTasks = new List<Task>();
            BDTasksController.GetAllLastResolvedTasks(id).ForEach((item) => { resolvedTasks.Add(new Task(item)); });
            var report = new Report(Guid.NewGuid(), id, resolvedTasks, description);
            CreateDailyReport(report);
            if (resolvedTasks.Count != 0)
                BDTasksController.DeleteLastResolvedTasks(id);
            
        }
        
        public static void CreateSprintReport(Guid id, string description = null)
        {
            if (BDTasksController.GetAllLastResolvedTasks(id) != null 
                && BDTasksController.GetAllLastResolvedTasks(id).Count != 0) 
                CreateDailyReport(id);
            var report = new Report(Guid.NewGuid()
                , id
                , GetAllResolvedTasks(id)
                , description);
            CreateSprintReportEmployee(report);
        }

        public static Report GetSprintReport() {
            return AccessBDReports.GetSprintReport();
        }
    }
}