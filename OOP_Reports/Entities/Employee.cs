using System;
using System.Collections.Generic;
using OOP_Reports.BLL;
using OOP_Reports.DAL;

namespace OOP_Reports.Entities {
    public class Employee {
        public bool IsTeamLead = false;
        public string Name { get; set; }
        public Guid Leader { get; set; }
        public List<Guid> Underlings { get; set; } = new List<Guid>();
        
        public Employee(string name) {
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

        public void CreateDailyReport()
        {
            
        }
    }
}