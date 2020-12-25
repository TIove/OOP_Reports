using System;
using System.Linq;
using NUnit.Framework;
using OOP_Reports;
using OOP_Reports.BLL;
using OOP_Reports.DataBases;
using OOP_Reports.Entities;
using OOP_Reports.Entities.Task;

namespace UnitTests {
    public class UnitTest2 {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Test1() {
            var em1 = new Employee("Vasya");
            var em2 = new Employee("Igor");
            BDStaffController.AddEmployee(em1);
            BDStaffController.AddEmployee(em2);
            BDStaffController.GetEmployee(em1.Id).AddLeader(em2.Id);
            Task task1 = new Task("task1", "description", em1.Id, Status.Open, DateTime.Now);
            BDTasksController.AddNewTask(task1);
            task1.Description = "New desc";
            BDTasksController.EditTask(task1);
            BDTasksController.Resolve(task1.Id);
            
            em1.CreateDailyReport("Some description");
            Assert.True(BDReportsController.GetAllDailyReportsEmployeeId(em1.Id)
                .Exists(rep => rep.SolvedTasks.Exists(tsk => tsk.Id == task1.Id)));
        }

        [Test]
        public void Test2() {
            var em1 = new Employee("Vasya");
            var em2 = new Employee("Igor");
            BDStaffController.AddEmployee(em1);
            BDStaffController.AddEmployee(em2);
            BDStaffController.GetEmployee(em1.Id).AddLeader(em2.Id);
            
            Task task1 = new Task("task1", "description", em1.Id, Status.Open, DateTime.Now);
            BDTasksController.AddNewTask(task1);
            task1.Description = "New desc";
            BDTasksController.EditTask(task1);
            BDTasksController.Resolve(task1.Id);
            em1.CreateDailyReport("Some description");
            
            Task task2 = new Task("task1", "description", em1.Id, Status.Open, DateTime.Now);
            BDTasksController.AddNewTask(task2);
            task2.Description = "New desc2";
            BDTasksController.EditTask(task2);
            BDTasksController.Resolve(task2.Id);
            em1.CreateDailyReport("Some description");
            
            em1.CreateSprintReport("Final");
            
            Assert.True(BDReports.Reports[em1.Id].Exists(x => x.SolvedTasks.All(y => y.Id == task1.Id || y.Id == task2.Id)));
        }

        [Test]
        public void Test3() {
            var em1 = new Employee("Vasya");
            var em2 = new Employee("Igor");
            var em3 = new Employee("Igorok Leader");
            
            BDStaffController.AddEmployee(em1);
            BDStaffController.AddEmployee(em2);
            BDStaffController.AddEmployee(em3);
            BDStaffController.GetEmployee(em1.Id).AddLeader(em2.Id);
            BDStaffController.SetNewLeader(em3.Id, em2.Id);
            Task task1 = new Task("task1", "description", em1.Id, Status.Open, DateTime.Now);
            BDTasksController.AddNewTask(task1);
            task1.Description = "New desc";
            BDTasksController.EditTask(task1);
            BDTasksController.Resolve(task1.Id);
            em1.CreateDailyReport("Some description");
            
            Task task2 = new Task("task1", "description", em2.Id, Status.Open, DateTime.Now);
            BDTasksController.AddNewTask(task2);
            task2.Description = "New desc2";
            BDTasksController.EditTask(task2);
            BDTasksController.Resolve(task2.Id);
            em2.CreateDailyReport("Some description");
            
            em1.CreateSprintReport("Final1");
            em2.CreateSprintReport("Final2");
            
            em3.CreateSprintReport();
            
            Assert.True(BDReports.Reports[em3.Id].Exists(x => x.Mode == ModeReport.TeamLeadSprint));
        }
    }
}