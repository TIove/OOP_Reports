using System;
using System.Collections.Generic;
using System.Linq;
using Lab6.BLL;
using Lab6.DataBases;
using Lab6.Entities;
using Lab6.Entities.Report;
using Lab6.Entities.Task;

namespace Lab6.DAL
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

        public static Report GetSprintReport() {
            foreach (var lRep in BDReports.Reports.Values) {
                foreach (var report in lRep) {
                    if (report.Mode == ModeReport.TeamLeadSprint)
                        return report;
                }
            }

            return null;
        }
    }
}