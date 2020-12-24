using System;
using OOP_Reports.DAL;
using OOP_Reports.DataBases;
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

        public static void SetNewLeader(Guid leaderId, Guid employeeId)
        {
            var employee = AccessBDStaff.Get(employeeId);
            var lead = AccessBDStaff.Get(leaderId);
            lead.Underlings.Add(employee.Id);
            employee.Leader = leaderId;
            AccessBDStaff.Update(employee);
            AccessBDStaff.Update(lead);
        }
    }
}