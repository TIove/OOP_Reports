using Lab6.PL;
using Lab6.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void Button_AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddUnderling add = new AddUnderling();
            add.Show();
        }

        private void Button_AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTask add = new AddTask();
            add.Show();
        }

        private void Button_EndTask_Click(object sender, RoutedEventArgs e)
        {
            EndTask endTask = new EndTask();
            endTask.Show();
        }

        private void Button_DailyReport_Click(object sender, RoutedEventArgs e)
        {
            DailyReport daily = new DailyReport();
            daily.Show();
        }

        private void Button_SprintReport_Click(object sender, RoutedEventArgs e)
        {
            SprintReport sprint = new SprintReport();
            sprint.Show();
        }

        private void Button_ShowStuff_Click(object sender, RoutedEventArgs e)
        {
            ShowStaff staff = new ShowStaff();
            staff.Show();
        }

        private void Button_ShowTasks_Click(object sender, RoutedEventArgs e)
        {
            ShowTasks tasks = new ShowTasks();
            tasks.Show();
        }
    }
}
