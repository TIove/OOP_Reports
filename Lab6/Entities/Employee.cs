using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Lab6.BLL;
using Lab6.DAL;
using Lab6.DataBases;

namespace Lab6.Entities {
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
            return $"\nId - {Id}\n" +
                   $"Name - {Name}\n";
        }
    }
}