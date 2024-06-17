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
    /// Логика взаимодействия для AddNewGroupWindow.xaml
    /// </summary>
    public partial class AddNewGroupWindow : Window
    {
        private Groups _currentGroup = new Groups();
        public AddNewGroupWindow(Groups selectedGroup)
        {
            InitializeComponent();

            if (selectedGroup != null)
            {
                _currentGroup = selectedGroup;
                AddBtn.Content = "Сохранить";
                windowTitle.Text = "Редактирование группы";
            }

            DataContext = _currentGroup;
        }

        private void Add_Group(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (ShtNTB.Text == "")
                Errors.AppendLine("Не указанно сокращённое название!");
            if (FullNTB.Text == "")
                Errors.AppendLine("Не указанно название!");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (_currentGroup.ID == 0)
            {
                Project_accounting_DBEntities.GetContext().Groups.Add(_currentGroup);
            }

            try
            {
                Project_accounting_DBEntities.GetContext().SaveChanges();
                MessageBox.Show("Группа сохранена", "Успех", MessageBoxButton.OK);
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
