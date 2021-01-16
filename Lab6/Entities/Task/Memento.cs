using System;

namespace Lab6.Entities.Task
{
    public class Memento
    {
        public Guid Id { get;}
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime LastUpdate { get; }

        public Memento(Guid id, Status? status = null, string description = null)
        {
            Id = id;
            if (description != null)
                Description = description;
            if (status != null)
                Status = status.Value;
            LastUpdate = DateTime.Now;
        }
    }
}