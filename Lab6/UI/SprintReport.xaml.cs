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
    /// Логика взаимодействия для SprintReport.xaml
    /// </summary>
    public partial class SprintReport : Window
    {
        public SprintReport()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Guid idEmplSprint;
            if (!Guid.TryParse(EId.Text, out idEmplSprint))
            {
                MessageBox.Show("Неправильный формат id");
                
            }
            else
            {
                var descSprintRep = TDisc.Text;
                BDReportsController.CreateSprintReport(idEmplSprint, descSprintRep);
                if (BDStaffController.GetEmployee(idEmplSprint).IsTeamLead)
                {
                    MessageBox.Show("Отчет за спринт\n" +
                                      BDReportsController.GetSprintReport());
                    Environment.Exit(0);
                }
            }
        }
    }
}
