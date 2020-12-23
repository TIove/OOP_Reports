using System;

namespace OOP_Reports.Entities {
    public class Task {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Owner { get; set; }
        public Status Status { get; set; }
        public DateTime LastUpdate;

        public Task() {
            
        }
    }
}