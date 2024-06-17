using Progect_accounting.Database;
using Progect_accounting.Windows;
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

namespace Progect_accounting.Frames
{
    /// <summary>
    /// Логика взаимодействия для UsersInformation.xaml
    /// </summary>
    public partial class UsersInformation : Page
    {
        public UsersInformation()
        {
            InitializeComponent();
            Update_Table();
        }

        void Update_Table()
        {
             DGrid.ItemsSource = Project_accounting_DBEntities.GetContext().Users.ToList();
        }

        private void Add_User(object sender, RoutedEventArgs e)
        {
            AddNewUserWindow ANUW = new AddNewUserWindow(null);
            ANUW.ShowDialog();
            Update_Table();
        }

        private void Edit_User(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                AddNewUserWindow ANUW = new AddNewUserWindow(DGrid.SelectedItem as Users);
                ANUW.ShowDialog();
                Update_Table();
            }
            else
            {
                MessageBox.Show("Выберите редактируемого пользователя", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Del_User(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var removing = DGrid.SelectedItems.Cast<Users>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        foreach (var rem in removing)
                        {
                            Project_accounting_DBEntities.GetContext().Users.Remove(rem);
                        }
                        Project_accounting_DBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удаленны", "Успех", MessageBoxButton.OK);
                        Update_Table();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите удаляемого пользователя", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
