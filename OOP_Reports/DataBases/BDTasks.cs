using System;
using System.Collections.Generic;
using OOP_Reports.Entities;
using OOP_Reports.Entities.Task;

namespace OOP_Reports.DataBases {
    public class BDTasks {
        public static Dictionary<Guid, List<Task>> ListOfTasks = new Dictionary<Guid, List<Task>>();
        public static Dictionary<Guid, List<Memento>> ListsOfChanges = new Dictionary<Guid, List<Memento>>(); 
    }
}