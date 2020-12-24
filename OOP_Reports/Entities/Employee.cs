using System;
using System.Collections.Generic;
using OOP_Reports.BLL;
using OOP_Reports.DAL;
using OOP_Reports.DataBases;

namespace OOP_Reports.Entities {
    public class Employee {
        public Guid Id { get; set; }
        public bool IsTeamLead = false;
        public string Name { get; set; }
        public Guid Leader { get; set; }
        public List<Guid> Underlings { get; set; } = new List<Guid>();
        
        public Employee(string name) {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void AddNewTask(Task.Task task)
        {
            BDTasksController.AddNewTask(task);
        }

        public void ChangeTask(Task.Task task)
        {
            BDTasksController.EditTask(task);
        }
        
        public void ResolveTask(Guid id)
        {
            BDTasksController.Resolve(id);
        }

        public void CreateDailyReport(string description = null)
        {
            var resolvedTasks = BDTasksController.GetAllLastResolvedTasks(Id);
            BDTasksController.DeleteLastResolvedTasks(Id);
            var report = new Report.Report(Guid.NewGuid(), Id, resolvedTasks, description);
            BDReportsController.CreateDailyReport(report);
        }

        public void CreateSprintReport(string description = null)
        {
            if (BDTasksController.GetAllLastResolvedTasks(Id).Count != 0) 
                CreateDailyReport();

            BDReportsController.CreateSprintReportEmployee(new Report.Report( Guid.NewGuid()
                    , Id
                    , BDReportsController.GetAllResolvedTasks(Id)
                    , description));
        }
    }
}