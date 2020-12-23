using System;
using OOP_Reports.DAL;
using OOP_Reports.Entities;
using OOP_Reports.Entities.Task;

namespace OOP_Reports.BLL
{
    public class BDTasksController
    {
        public static void AddNewTask(Task task)
        {
            AccessBDTasks.AddTask(task);
        }

        public static void EditTask(Task task)
        {
            AccessBDTasks.UpdateTask(task);
        }
        
        public static void Resolve(Guid id)
        {
            var task = AccessBDTasks.GetTask(id);
            task.Status = Status.Resolved;
            AccessBDTasks.UpdateTask(task);
        }
    }
}