using System;
using System.Collections.Generic;
using OOP_Reports.BLL;

namespace OOP_Reports.Entities.Report {
    public class Report {
        public Guid Id { get; }
        public Guid Owner { get; }
        public ModeReport Mode;
        public string Description { get; }
        public List<Task.Task> SolvedTasks;

        public DateTime TimeOfCreate { get; }

        public Report(Guid id, Guid owner,List<Task.Task> solvedTasks, string description = null)
        {
            Id = id;
            Owner = owner;
            SolvedTasks = solvedTasks;
            Description = description;
            TimeOfCreate = DateTime.Now;
        }

        public override string ToString() {
            string s = "";
            foreach (var task in SolvedTasks) {
                s += task.Name + '\n';
            }
            return "Отчет\n" +
                   $"Создатель отчета - {BDStaffController.GetEmployee(Owner).Name}\n" +
                   $"Описание - {Description}\n" +
                   $"Выполненные задачи:\n {s}";
        }
    }
}