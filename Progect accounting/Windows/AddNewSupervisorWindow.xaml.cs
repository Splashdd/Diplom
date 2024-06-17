using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Windows.Shapes;
using Progect_accounting.Database;

namespace Progect_accounting.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewSupervisorWindow.xaml
    /// </summary>
    public partial class AddNewSupervisorWindow : Window
    {
        private Supervisors _currentSupervisor = new Supervisors();
        public AddNewSupervisorWindow(Supervisors selectedSupervisor)
        {
            InitializeComponent();

            if (selectedSupervisor != null)
            {
                _currentSupervisor = selectedSupervisor;
                AddBtn.Content = "Сохранить";
                windowTitle.Text = "Изменение руководителя";
            }

            DataContext = _currentSupervisor;
        }

        private void Add_Supervisor(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
                if (FullNTB.Text == "")
                Errors.AppendLine("Укажите ФИО руководителя!");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (_currentSupervisor.ID == 0)
            {
                Project_accounting_DBEntities.GetContext().Supervisors.Add(_currentSupervisor);
            }

            try
            {
                Project_accounting_DBEntities.GetContext().SaveChanges();
                MessageBox.Show("Руководитель сохранён", "Успех", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
