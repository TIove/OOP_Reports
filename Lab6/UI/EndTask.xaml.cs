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
    /// Логика взаимодействия для EndTask.xaml
    /// </summary>
    public partial class EndTask : Window
    {
        public EndTask()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guid idTask;
            if (!Guid.TryParse(TId.Text, out idTask))
            {
                MessageBox.Show("Неправильный формат id");
            }
            else
            {
                try
                {
                    BDTasksController.Resolve(idTask);
                    MessageBox.Show("Успех");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
    }
}
