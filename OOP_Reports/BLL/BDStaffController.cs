using System;
using System.Collections.Generic;
using System.Linq;
using OOP_Reports.DAL;
using OOP_Reports.DataBases;
using OOP_Reports.Entities;

namespace OOP_Reports.BLL
{
    public class BDStaffController
    {
        public static List<Employee> GetAllStaffIdList() {
            return BDStaff.ListOfStaff.Values.ToList();
        }
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
        public void AddUnderlings(List<Guid> ids, Guid leader)
        {
            GetEmployee(leader).Underlings.AddRange(ids);
        }
        public void AddLeader(Guid leaderId, Guid employee)
        {
            if (GetEmployee(employee).IsTeamLead)
            {
                var newEmployee =  GetEmployee(employee);
                newEmployee.IsTeamLead = false;
                AccessBDStaff.Update(newEmployee);
            }
            
            SetNewLeader(leaderId, employee);
        }
    }
}