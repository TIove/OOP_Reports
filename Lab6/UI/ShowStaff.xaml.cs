using Lab6.BLL;
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
    /// Логика взаимодействия для ShowStuff.xaml
    /// </summary>
    public partial class ShowStaff : Window
    {
        private void SetFormatedStaff()
        {
            string str = "";
            foreach (var employee in BDStaffController.GetAllStaffIdList())
            {
                str += employee.ToString() + '\n';
            }
            Staff.Text = str;
        }
        public ShowStaff()
        {
            InitializeComponent();
            SetFormatedStaff();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetFormatedStaff();
        }
    }
}
