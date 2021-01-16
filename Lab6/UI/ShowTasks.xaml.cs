using Lab6.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab6.UI
{
    /// <summary>
    /// Логика взаимодействия для ShowTasks.xaml
    /// </summary>
    public partial class ShowTasks : Window
    {
        public ShowTasks()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            Tasks.Text = "";
            Guid idEmplSprint;
            if (!Guid.TryParse(EId.Text, out idEmplSprint))
            {
                MessageBox.Show("Неправильный формат id");
            }
            else
            {
                try
                {
                    foreach (var task in AccessBDTasks.GetTasksByEmployeeId(idEmplSprint))
                    {
                        if (task.Status == Status.Open)
                            str += "Id - " + task.Id + " Name - " + task.Name + " Description - " + task.Description + '\n';
                    }
                    Tasks.Text = str;
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show("Нет такого сотрудника, либо сотрудник пока не содержит задач");
                }
            }
        }
    }
}
