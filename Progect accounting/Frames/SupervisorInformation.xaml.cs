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
    /// Логика взаимодействия для SupervisorInformation.xaml
    /// </summary>
    public partial class SupervisorInformation : Page
    {
        public SupervisorInformation()
        {
            InitializeComponent();
            Update_Table();
        }

        private void Update_Table()
        {
            DGrid.ItemsSource = Project_accounting_DBEntities.GetContext().Supervisors.ToList();
        }

        private void Add_Supervisor(object sender, RoutedEventArgs e)
        {
            AddNewSupervisorWindow ANSW = new AddNewSupervisorWindow(null);
            ANSW.ShowDialog();
            Update_Table();
        }

        private void Edit_Supervisor(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                AddNewSupervisorWindow ANSW = new AddNewSupervisorWindow(DGrid.SelectedItem as Supervisors);
                ANSW.ShowDialog();
            }
            else
                MessageBox.Show("Выберите редактируемого руководителя!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            Update_Table();
        }

        private void Del_Supervisor(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var Removing = DGrid.SelectedItems.Cast<Supervisors>().ToList();

                foreach (var check in Removing)
                {
                    if (Project_accounting_DBEntities.GetContext().Projects.FirstOrDefault(n => n.Supervisor_ID == check.ID) != null)
                    {
                        MessageBox.Show($"В работах указывается проверяющий с именнем {check.FullName}, для удаление очистите записи с данным проверяющим!",
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
                            Project_accounting_DBEntities.GetContext().Supervisors.Remove(rem);
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
                MessageBox.Show("Выберите удаляемоого руководителя!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
