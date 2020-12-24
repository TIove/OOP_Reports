using System;
using System.Collections.Generic;

namespace OOP_Reports.Entities.Report {
    public class Report {
        public Guid Id { get; set; }
        public Guid Owner { get; set; }
        public ModeReport Mode;
        public string Description { get; set; }
        public List<Task.Task> SolvedTasks;

        public DateTime TimeOfCreate { get; set; }

        public Report(Guid id, Guid owner,List<Task.Task> solvedTasks, string description = null)
        {
            Id = id;
            Owner = owner;
            SolvedTasks = solvedTasks;
            Description = description;
            TimeOfCreate = DateTime.Now;
        }
    }
}