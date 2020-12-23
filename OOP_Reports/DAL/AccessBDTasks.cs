using System;
using System.Collections.Generic;
using System.Linq;
using OOP_Reports.DataBases;
using OOP_Reports.Entities;
using OOP_Reports.Entities.Task;


namespace OOP_Reports.DAL
{
    public class AccessBDTasks
    {
        public static Task GetTask(Guid id)
        {
            return BDTasks.ListOfTasks.Values
                .First(x => x.Exists(y => y.Id.Equals(id)))
                .Find(x => x.Id.Equals(id));
        }
        public static void AddTask(Task task)
        {
            AddMemento(new Memento(task.Id, task.Status, task.Description));
            if (BDTasks.ListOfTasks.ContainsKey(task.Owner))
                BDTasks.ListOfTasks[task.Owner].Add(task);
            else
                BDTasks.ListOfTasks.Add(task.Owner, new List<Task>() {task});
        }

        public static void RemoveTask(Guid id)
        {
            AddMemento(GetTask(id).Changes(null));
            BDTasks.ListOfTasks.Remove(id);
        }

        public static void UpdateTask(Task task)
        {
            var before = BDTasks.ListOfTasks[task.Owner].Find(x => x.Id.Equals(task.Id));
            if (before != null)
                AddMemento(before.Changes(task));
            
            BDTasks.ListOfTasks[task.Owner]
                .Insert(BDTasks.ListOfTasks[task.Owner]
                    .FindIndex(x => x.Id.Equals(task.Id)), task);
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
    }
}