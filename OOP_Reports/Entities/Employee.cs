using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OOP_Reports.BLL;
using OOP_Reports.DAL;
using OOP_Reports.DataBases;

namespace OOP_Reports.Entities {
    public class Employee {
        public Guid Id { get; set; }
        public bool IsTeamLead = false;
        public string Name { get; set; }
        public Guid Leader { get; set; } = Guid.Empty;
        public List<Guid> Underlings { get; set; } = new List<Guid>();
        
        public Employee(string name) {
            Id = Guid.NewGuid();
            Name = name;
            if (Leader.Equals(Guid.Empty))
            {
                IsTeamLead = true;
            }
        }

        public void AddUnderlings(List<Guid> ids)
        {
            Underlings.AddRange(ids);
        }

        public void AddLeader(Guid leaderId)
        {
            if (IsTeamLead)
            {
                IsTeamLead = false;
            }
            BDStaffController.SetNewLeader(leaderId, Id);
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
        //     oldList.ForEach((item)=> { newList.Add(new SomeType(item));});
            var resolvedTasks = new List<Task.Task>();
            BDTasksController.GetAllLastResolvedTasks(Id).ForEach((item) => { resolvedTasks.Add(new Task.Task(item)); });
            var report = new Report.Report(Guid.NewGuid(), Id, resolvedTasks, description);
            BDReportsController.CreateDailyReport(report);
            BDTasksController.DeleteLastResolvedTasks(Id);
        }

        public void CreateSprintReport(string description = null)
        {
            if (BDTasksController.GetAllLastResolvedTasks(Id) != null 
                && BDTasksController.GetAllLastResolvedTasks(Id).Count != 0) 
                CreateDailyReport();
            var report = new Report.Report(Guid.NewGuid()
                , Id
                , BDReportsController.GetAllResolvedTasks(Id)
                , description);
            BDReportsController.CreateSprintReportEmployee(report);
        }
    }
}