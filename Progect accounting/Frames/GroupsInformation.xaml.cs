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
    /// Логика взаимодействия для GroupsInformation.xaml
    /// </summary>
    public partial class GroupsInformation : Page
    {
        public GroupsInformation()
        {
            InitializeComponent();
            Update_Table();
        }

        private void Update_Table()
        {
            DGrid.ItemsSource = Project_accounting_DBEntities.GetContext().Groups.ToList();
        }

        private void Add_group(object sender, RoutedEventArgs e)
        {
            AddNewGroupWindow ANGW = new AddNewGroupWindow(null);
            ANGW.ShowDialog();
            Update_Table();
        }

        private void Edit_group(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                AddNewGroupWindow ANPW = new AddNewGroupWindow(DGrid.SelectedItem as Groups);
                ANPW.ShowDialog();
            }
            else
                MessageBox.Show("Выберите редактируемую группу!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            Update_Table();
        }

        private void Del_group(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var Removing = DGrid.SelectedItems.Cast<Groups>().ToList();

                foreach (var check in Removing)
                {
                    if (Project_accounting_DBEntities.GetContext().Projects.FirstOrDefault(n => n.Group_ID == check.ID) != null)
                    {
                        MessageBox.Show($"В работах указывается группа с именнем {check.ShortName}, для удаление очистите записи с данными группами!",
                                        "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        foreach (var rem in Removing)
                        {
                            Project_accounting_DBEntities.GetContext().Groups.Remove(rem);
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
                MessageBox.Show("Выберите удаляемую группу!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
