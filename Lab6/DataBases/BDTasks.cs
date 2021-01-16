using System;
using System.Collections.Generic;
using Lab6.Entities;
using Lab6.Entities.Task;

namespace Lab6.DataBases {
    public class BDTasks {
        public static Dictionary<Guid, List<Task>> ListsOfTasks = new Dictionary<Guid, List<Task>>();
        public static Dictionary<Guid, List<Memento>> ListsOfChanges = new Dictionary<Guid, List<Memento>>();
        public static Dictionary<Guid, List<Task>> ListsOfLastResolvedTasks = new Dictionary<Guid, List<Task>>();
    }
}