using System;
using System.Collections.Generic;
using System.Linq;
using Lab6.DataBases;
using Lab6.Entities;
using Lab6.Entities.Task;


namespace Lab6.DAL
{
    public class AccessBDTasks
    {
        public static List<Task> GetAllTasksByEmployeeId(Guid employeeId) {
            return BDTasks.ListsOfTasks[employeeId];
        }
        public static Task GetTaskById(Guid id)
        {
            return BDTasks.ListsOfTasks.Values
                .First(x => x.Exists(y => y.Id.Equals(id)))
                .Find(x => x.Id.Equals(id));
        }

        public static List<Task> GetTasksByUpdateDate(DateTime dateTime)
        { 
            return (from val in BDTasks.ListsOfTasks.Values 
                from task in val 
                where task.LastUpdate.Date == dateTime.Date 
                select task)
                .ToList();
        }

        public static List<Task> GetTasksByEmployeeId(Guid id)
        {
            return BDTasks.ListsOfTasks[id];
        }

        public static List<Task> GetAllUpdatedTasks(Guid id)
        {
            return (from val in BDTasks.ListsOfChanges[id] 
                from task in BDTasks.ListsOfTasks[id] 
                where task.Id == val.Id 
                select task)
                .ToList();
        }

        public static void AddTask(Task task)
        {
            AddMemento(new Memento(task.Id, task.Status, task.Description));
            if (BDTasks.ListsOfTasks.ContainsKey(task.Owner))
                BDTasks.ListsOfTasks[task.Owner].Add(task);
            else
                BDTasks.ListsOfTasks.Add(task.Owner, new List<Task>() {task});
        }

        public static void RemoveTask(Guid id)
        {
            AddMemento(GetTaskById(id).Changes(null));
            BDTasks.ListsOfTasks.Remove(id);
        }

        public static void UpdateTask(Task task)
        {
            task.LastUpdate = DateTime.Now;
            var before = BDTasks.ListsOfTasks.Values
                .First(x => x.Exists(y => y.Id.Equals(task.Id)))
                .Find(x => x.Id.Equals(task.Id));
            if (before != null)
                AddMemento(before.Changes(task));

            if (before == null || task.Owner == before.Owner)
            {
                BDTasks.ListsOfTasks[task.Owner]
                    .Insert(BDTasks.ListsOfTasks[task.Owner].FindIndex(x => x.Id.Equals(task.Id)), task);
            }
            else
            {
                BDTasks.ListsOfTasks[before.Owner]
                    .RemoveAt(BDTasks.ListsOfTasks[before.Owner].FindIndex(x => x.Id.Equals(before.Id)));
                BDTasks.ListsOfTasks[task.Owner].Add(task);
            }
        }

        public static void GetMemento()
        {
            
        }

        public static void AddMemento(Memento memento)
        {
            if (BDTasks.ListsOfChanges.ContainsKey(memento.Id))
                BDTasks.ListsOfChanges[memento.Id].Add(memento);
            else
                BDTasks.ListsOfChanges.Add(memento.Id, new List<Memento>() {memento});
        }

        public static void AddNewResolvedTask(Task task)
        {
            if (BDTasks.ListsOfLastResolvedTasks.ContainsKey(task.Owner))
                BDTasks.ListsOfLastResolvedTasks[task.Owner].Add(task);
            else
                BDTasks.ListsOfLastResolvedTasks.Add(task.Owner, new List<Task>() {task});
        }
        
        public static List<Task> GetLastResolvedTasks(Guid id) {
            if (BDTasks.ListsOfLastResolvedTasks.ContainsKey(id))
                return BDTasks.ListsOfLastResolvedTasks[id];
            else
                return new List<Task>();
        }

        public static void DeleteLastResolvedTasks(Guid id)
        {
            BDTasks.ListsOfLastResolvedTasks[id].Clear();
        }
    }
}