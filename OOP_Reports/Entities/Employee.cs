using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OOP_Reports.BLL;
using OOP_Reports.DAL;
using OOP_Reports.DataBases;

namespace OOP_Reports.Entities {
    public class Employee {
        public Guid Id { get;}
        public bool IsTeamLead = false;
        public string Name { get; }
        public Guid Leader { get; set; } = Guid.Empty;
        public List<Guid> Underlings { get;} = new List<Guid>();
        
        public Employee(string name) {
            Id = Guid.NewGuid();
            Name = name;
            if (Leader.Equals(Guid.Empty))
            {
                IsTeamLead = true;
            }
        }

        public override string ToString() {
            return $"\nId - {Id} " +
                   $"Name = {Name}\n";
        }
    }
}