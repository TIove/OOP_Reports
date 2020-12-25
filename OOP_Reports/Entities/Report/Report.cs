using System;
using System.Collections.Generic;

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
    }
}