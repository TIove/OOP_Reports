using System;
using System.Collections.Generic;
using System.IO;
using Lab6.Entities.Report;

namespace Lab6.DataBases {
    public class BDReports
    {
        public static Dictionary<Guid, List<Report>> Reports = new Dictionary<Guid, List<Report>>();
    }
}