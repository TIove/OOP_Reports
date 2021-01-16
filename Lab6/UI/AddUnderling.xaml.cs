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

namespace Lab6.PL
{
    /// <summary>
    /// Логика взаимодействия для AddUnderling.xaml
    /// </summary>
    public partial class AddUnderling : Window
    {
        public AddUnderling()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Guid lId;
            bool isLIdGuid = Guid.TryParse(LName.Text, out lId);
            Guid eId;
            bool isEIdGuid = Guid.TryParse(EName.Text, out eId);
            if (isEIdGuid && isLIdGuid)
            {
                BDStaffController.SetNewLeader(lId, eId);
                MessageBox.Show("Успех");
                Save.IsEnabled = false;
            }
            else
                MessageBox.Show("Неверные id");
        }
    }
}
