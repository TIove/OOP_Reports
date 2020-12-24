using System;
using System.Collections.Generic;
using OOP_Reports.DataBases;
using OOP_Reports.Entities;

namespace OOP_Reports.DAL {
    public class AccessBDStaff {
        public static void AddNewEmployee(Employee employee)
        {
            BDStaff.ListOfStaff[employee.Id] = employee;
        }

        public static void RemoveEmployee(Guid id)
        {
            BDStaff.ListOfStaff.Remove(id);
        }

        public static Employee Get(Guid id)
        {
            return BDStaff.ListOfStaff.GetValueOrDefault(id, null);
        }

        public static void Update(Employee employee)
        {
            BDStaff.ListOfStaff[employee.Id] = employee;
        }
        
    }
}