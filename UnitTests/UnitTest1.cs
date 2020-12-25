using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NUnit.Framework;
using OOP_Reports;
using OOP_Reports.BLL;
using OOP_Reports.Entities;
using Task = OOP_Reports.Entities.Task.Task;

namespace UnitTests {
    public class Tests {
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
            Assert.Contains(em1.Id, em2.Underlings);
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
            BDTasksController.SetActiveState(task1.Id);
            Assert.AreEqual(Status.Active, BDTasksController.GetTaskById(task1.Id).Status);
            BDTasksController.SetUnActiveState(task1.Id);
            Assert.AreEqual(Status.Open, BDTasksController.GetTaskById(task1.Id).Status);
        }

        [Test]
        public void Test3() {
            var em1 = new Employee("Vasya");
            var em2 = new Employee("Igor");
            BDStaffController.AddEmployee(em1);
            BDStaffController.AddEmployee(em2);
            BDStaffController.GetEmployee(em1.Id).AddLeader(em2.Id);
            Task task1 = new Task("task1", "description", em1.Id, Status.Open, DateTime.Now);
            BDTasksController.AddNewTask(task1);
            task1.Description = "New desc";
            BDTasksController.EditTask(task1);
            Assert.AreEqual(task1, BDTasksController.GetTaskById(task1.Id));
        }
    }
}