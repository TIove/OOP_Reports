using System;
using OOP_Reports.DAL;
using OOP_Reports.Entities;

namespace OOP_Reports.BLL
{
    public class BDStaffController
    {
        public static Employee GetEmployee(Guid id)
        {
            return AccessBDStaff.Get(id);
        }

        public static void AddEmployee(Employee employee)
        {
            AccessBDStaff.AddNewEmployee(employee);
        }

        
    }
}