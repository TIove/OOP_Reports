using System;
using System.Collections.Generic;
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

        public void AddNewUnderlings(params Guid[] peopleId) {
            foreach (var id in peopleId) {
                Underlings.Add(id);
                AccessBDStaff
            }
        }
        
    }
}