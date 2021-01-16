using Lab6.BLL;
using Lab6.Entities.Task;
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
    /// Логика взаимодействия для AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Guid owner;
            if (!Guid.TryParse(EId.Text, out owner))
            {
                MessageBox.Show("Неправильный формат id");
            }
            else
            {
                Task task = new Task(TName.Text, TDisc.Text, owner, Status.Open, DateTime.Now);
                BDTasksController.AddNewTask(task);
                MessageBox.Show("Успех!");
                this.Close();
            }
        }
    }
}
