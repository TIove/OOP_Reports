using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using OOP_Reports.BLL;
using OOP_Reports.DAL;
using OOP_Reports.Entities;
using OOP_Reports.Entities.Task;
using Task = OOP_Reports.Entities.Task.Task;

namespace OOP_Reports.UI {
    public class Menu {
        public void Start() {
            GetCommand();
        }

        private void PrintStartMenu() {
            Console.WriteLine(
                "0. Выйти\n" +
                "1. Создать сотрудника\n" +
                "2. Добавить сотруднику подчиненного\n" +
                "3. Создать задачу у сотрудника\n" +
                "4. Завершить задачу у сотрудника\n" +
                "5. Создать отчет за день у сотрудника\n" +
                "6. Создать отчет за спринт у сотрудника\n" +
                "7. Посмотреть все ID сотрудников\n" +
                "8. Псмотреть все задачи сотрудника"
            );
        }

        private void GetCommand() {
            bool isEnd = false;
            while (true) {
                if (isEnd)
                    break;
                PrintStartMenu();
                int cmd = 0;
                try {
                    cmd = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception) {
                    Console.WriteLine("Неверное число");
                    continue;
                }
                
                if (cmd == 0)
                    break;
                switch (cmd) {
                    case 1: {
                        Console.WriteLine("Введите имя");
                        var name = Console.ReadLine();
                        BDStaffController.AddEmployee(new Employee(name));
                        break;
                    }
                    case 2: {
                        Guid lId;
                        Console.WriteLine("Id лидера");
                        bool isLIdGuid = Guid.TryParse(Console.ReadLine(), out lId);
                        Guid eId;
                        Console.WriteLine("Id подчиненного");
                        bool isEIdGuid = Guid.TryParse(Console.ReadLine(), out eId);
                        if (isEIdGuid && isLIdGuid)
                            BDStaffController.SetNewLeader(lId, eId);
                        else
                            Console.WriteLine("Ошибка");
                        break;
                    }
                    case 3: {
                        Console.WriteLine("Введите id владельца задачи");
                        Guid owner;
                        if (!Guid.TryParse(Console.ReadLine(), out owner)) {
                            Console.WriteLine("Неправильный формат id");
                            break;
                        }

                        Console.WriteLine("Введите имя задачи");
                        var taskName = Console.ReadLine();
                        Console.WriteLine("Введите описание задачи");
                        var desc = Console.ReadLine();

                        Task task = new Task(taskName, desc, owner, Status.Open, DateTime.Now);
                        BDTasksController.AddNewTask(task);
                        break;
                    }
                    case 4: {
                        Console.WriteLine("Введите id задачи");
                        Guid idTask;
                        if (!Guid.TryParse(Console.ReadLine(), out idTask)) {
                            Console.WriteLine("Неправильный формат id");
                            break;
                        }

                        try {
                            BDTasksController.Resolve(idTask);
                            Console.WriteLine("Успех");
                        }
                        catch (Exception) {
                            Console.WriteLine("Ошибка");
                        }

                        break;
                    }
                    case 5: {
                        Console.WriteLine("Введите id сотрудника");
                        Guid idEmplDaily;
                        if (!Guid.TryParse(Console.ReadLine(), out idEmplDaily)) {
                            Console.WriteLine("Неправильный формат id");
                            break;
                        }

                        Console.WriteLine("Введите описание отчета");
                        var descDailRep = Console.ReadLine();
                        BDReportsController.CreateDailyReport(idEmplDaily, descDailRep);
                        break;
                    }
                    case 6: {
                        Console.WriteLine("Введите id сотрудника");
                        Guid idEmplSprint;
                        if (!Guid.TryParse(Console.ReadLine(), out idEmplSprint)) {
                            Console.WriteLine("Неправильный формат id");
                            return;
                        }

                        Console.WriteLine("Введите описание отчета");
                        var descSprintRep = Console.ReadLine();
                        BDReportsController.CreateSprintReport(idEmplSprint, descSprintRep);
                        if (BDStaffController.GetEmployee(idEmplSprint).IsTeamLead) {
                            isEnd = true;
                            Console.WriteLine("Отчет за спринт\n" + 
                                              BDReportsController.GetSprintReport());
                        }

                        break;
                    }
                    case 7: {
                        foreach (var employee in BDStaffController.GetAllStaffIdList()) {
                            Console.WriteLine(employee);
                        }

                        break;
                    }
                    case 8: {
                        Console.WriteLine("Введите id сотрудника");
                        Guid idEmplSprint;
                        if (!Guid.TryParse(Console.ReadLine(), out idEmplSprint)) {
                            Console.WriteLine("Неправильный формат id");
                            return;
                        }

                        try {
                            foreach (var task in AccessBDTasks.GetTasksByEmployeeId(idEmplSprint)) {
                                Console.WriteLine("\nId - " + task.Id
                                                            + " Name - " + task.Name
                                                            + " Description - " + task.Description + '\n');
                            }
                        }
                        catch (KeyNotFoundException ex) {
                            
                        }

                        break;
                    }
                    default:
                        Console.WriteLine("Неверное число");
                        break;
                }
            }
        }
    }
}