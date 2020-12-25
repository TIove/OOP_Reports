using System;
using System.Collections.Generic;
using System.Linq;
using OOP_Reports.BLL;
using OOP_Reports.DataBases;
using OOP_Reports.Entities;
using OOP_Reports.Entities.Report;
using OOP_Reports.Entities.Task;

namespace OOP_Reports.DAL
{
    public class AccessBDReports
    {
        public static void AddReport(Report report)
        {
            if (BDReports.Reports.ContainsKey(report.Owner))
                BDReports.Reports[report.Owner].Add(report);
            else
                BDReports.Reports.Add(report.Owner, new List<Report>() {report});
        }

        public static Report GetReport(Guid id)
        {
            return BDReports.Reports.Values
                .First(x => x.Exists(y => y.Id.Equals(id)))
                .Find(x => x.Id.Equals(id));
        }
        
        public static List<Report> GetAllReportsOfEmployee(Guid id) {
            if (BDReports.Reports.ContainsKey(id))
                return BDReports.Reports[id];
            else
                return new List<Report>();
        }

        public static List<Report> GetAllReportsOfUnderlings(Guid id) 
        {
            var res = new List<Report>();
            foreach (var underlingId in BDStaffController.GetEmployee(id).Underlings) {
                res.AddRange(GetAllReportsOfEmployee(underlingId));
            }

            return res;
        }
    }
}