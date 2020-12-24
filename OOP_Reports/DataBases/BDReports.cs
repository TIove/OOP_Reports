using System;
using System.Collections.Generic;
using System.IO;
using OOP_Reports.Entities.Report;

namespace OOP_Reports.DataBases {
    public class BDReports
    {
        public static Dictionary<Guid, List<Report>> Reports = new Dictionary<Guid, List<Report>>();
    }
}