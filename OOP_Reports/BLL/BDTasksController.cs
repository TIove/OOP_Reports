using System;
using System.Collections.Generic;
using OOP_Reports.DAL;
using OOP_Reports.Entities;
using OOP_Reports.Entities.Report;
using OOP_Reports.Entities.Task;

namespace OOP_Reports.BLL
{
    public class BDTasksController
    {
        public static Task GetTaskById(Guid id)
        {
            return AccessBDTasks.GetTaskById(id);
        }

        public static List<Task> GetTasksByUpdateDate(DateTime dateTime)
        {
            return AccessBDTasks.GetTasksByUpdateDate(dateTime);
        }
        public static List<Task> GetTasksByEmployeeId(Guid id)
        {
            return AccessBDTasks.GetTasksByEmployeeId(id);
        }

        public static List<Task> GetAllUpdatedTasks(Guid personId)
        {
            return AccessBDTasks.GetAllUpdatedTasks(personId);
        }

        public static List<Task> GetAllTasksOfUnderlings(List<Guid> underlings)
        {
            var res = new List<Task>();
            foreach (var id in underlings)
            {
                res.AddRange(GetTasksByEmployeeId(id));
            }

            return res;
        }
        
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
            var task = AccessBDTasks.GetTaskById(id);
            task.Status = Status.Resolved;
            AccessBDTasks.UpdateTask(task);
            AccessBDTasks.AddNewResolvedTask(AccessBDTasks.GetTaskById(id));
        }

        public static void SetActiveState(Guid id)
        {
            var task = AccessBDTasks.GetTaskById(id);
            task.Status = Status.Active;
            AccessBDTasks.UpdateTask(task);
        }
        
        public static void SetUnActiveState(Guid id)
        {
            var task = AccessBDTasks.GetTaskById(id);
            task.Status = Status.Open;
            AccessBDTasks.UpdateTask(task);
        }
        
        public static void ChangeOwnerById(Guid taskId, Guid newOwnerId)
        {
            var task = AccessBDTasks.GetTaskById(taskId);
            task.Owner = newOwnerId;
            AccessBDTasks.UpdateTask(task);
        }

        public static List<Task> GetAllLastResolvedTasks(Guid id)
        {
            return AccessBDTasks.GetLastResolvedTasks(id);
        }

        public static void DeleteLastResolvedTasks(Guid id)
        {
            AccessBDTasks.DeleteLastResolvedTasks(id);
        }
    }
}