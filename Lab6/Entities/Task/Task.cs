using System;

namespace Lab6.Entities.Task {
    public class Task {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; set; }
        public Guid Owner { get; set; }
        public Status Status { get; set; }
        public DateTime LastUpdate;

        public Task(string name, string description, Guid owner, Status status, DateTime time) {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Owner = owner;
            Status = status;
            LastUpdate = time;
        }

        public Task(Task task) {
            Id = task.Id;
            Name = task.Name;
            Description = task.Description;
            Owner = task.Owner;
            Status = task.Status;
            LastUpdate = task.LastUpdate;
        }
        public Memento Changes(Task after)
        {
            Memento changes = new Memento(Id);
            if (after != null)
            {
                if (Description != after.Description)
                    changes.Description = after.Description;
                if (Status != after.Status)
                    changes.Status = after.Status;
            }

            return changes;
        }
    }
}