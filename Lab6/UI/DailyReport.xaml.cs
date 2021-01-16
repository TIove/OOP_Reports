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
    /// Логика взаимодействия для DailyReport.xaml
    /// </summary>
    public partial class DailyReport : Window
    {
        public DailyReport()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Guid idEmplDaily;
            if (!Guid.TryParse(EId.Text, out idEmplDaily))
            {
                MessageBox.Show("Неправильный формат id");
            }
            else
            {
                var descDailRep = TDisc.Text;
                BDReportsController.CreateDailyReport(idEmplDaily, descDailRep);
                MessageBox.Show(BDReportsController.GetAllDailyReportsEmployeeId(idEmplDaily)[BDReportsController.GetAllDailyReportsEmployeeId(idEmplDaily).Count - 1].ToString());
                Close();
            }
        }
    }
}
