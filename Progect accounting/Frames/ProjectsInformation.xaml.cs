using Progect_accounting.Database;
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
using Progect_accounting.Windows;
using System.IO;
using System.Globalization;
using Microsoft.Win32;

namespace Progect_accounting.Frames
{
    /// <summary>
    /// Логика взаимодействия для ProjectsInformation.xaml
    /// </summary>
    
    public partial class ProjectsInformation : Page
    {
        public ProjectsInformation()
        {
            InitializeComponent();
            IntToStringConv converter = new IntToStringConv();
            Resources.Add("IntToStringConv", converter);
            Update_Table();
        }

        private void Update_Table()
        {
            DGrid.ItemsSource = Project_accounting_DBEntities.GetContext().Projects.ToList();
        }

        private void Add_project(object sender, RoutedEventArgs e)
        {
            AddNewProjectWindow ANPW = new AddNewProjectWindow(null);
            ANPW.ShowDialog();
            Update_Table();
        }

        private void Edit_project(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                AddNewProjectWindow ANPW = new AddNewProjectWindow(DGrid.SelectedItem as Projects);
                ANPW.ShowDialog();
            }
            else
                MessageBox.Show("Выберите редактируемый проект!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            
            Update_Table();
        }

        private void Del_project(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var Removing = DGrid.SelectedItems.Cast<Projects>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        foreach (var rem in Removing)
                        {
                            Project_accounting_DBEntities.GetContext().Projects.Remove(rem);
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
                MessageBox.Show("Выберите удаляемый проект!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Download_project(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var choose = DGrid.SelectedItems.Cast<Projects>().ToList();
                int idProj = choose.FirstOrDefault().ID;

                Projects proj = Project_accounting_DBEntities.GetContext().Projects.Find(idProj);
                byte[] data = (byte[])proj.Files;

                string projectType = null;
                if (proj.ProjectType == 0)
                {
                    projectType = "Курсовая работа";
                }
                else
                {
                    projectType = "Дипломная работа";
                }

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string fileName = path + $"\\{proj.FullName} {projectType} {proj.ProjectName}.zip";

                using (FileStream FS = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    FS.Write(data, 0, data.Length);
                    MessageBox.Show("Архив сохраннён на рабочий стол", "Успех", MessageBoxButton.OK);
                }
            }
            else
                MessageBox.Show("Выберите работу у которой хотите скачать архив", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Search_method(object sender, TextChangedEventArgs e)
        {
            if (SearchTxb.Text == "")
            {
                SearchBl.Visibility = Visibility.Visible;

                DGrid.ItemsSource = Project_accounting_DBEntities.GetContext().Projects.ToList();
            }
            else
            {
                SearchBl.Visibility = Visibility.Hidden;

                try
                {
                    var date = Convert.ToDateTime(SearchTxb.Text);

                    DGrid.ItemsSource = Project_accounting_DBEntities.GetContext().Projects.Where(i => i.CompleteDate == date).ToList();
                }
                catch
                {
                    try
                    {
                        int text = Convert.ToInt32(SearchTxb.Text);

                        DGrid.ItemsSource = Project_accounting_DBEntities.GetContext().Projects.Where(i => i.Mark == text).ToList();
                    }
                    catch
                    {
                        int projType = 0;

                        if (SearchTxb.Text == "Курсовая" && "Курсовая".Contains(SearchTxb.Text))
                            projType = 0;
                        if (SearchTxb.Text == "Дипломная" && "Дипломная".Contains(SearchTxb.Text))
                            projType = 1;

                        DGrid.ItemsSource = Project_accounting_DBEntities.GetContext().Projects.Where(i => i.Groups.ShortName == SearchTxb.Text || i.Groups.ShortName.Contains(SearchTxb.Text)
                                                                                      || i.FullName == SearchTxb.Text || i.FullName.Contains(SearchTxb.Text) 
                                                                                      || i.ProjectType == projType
                                                                                      || i.ProjectName == SearchTxb.Text || i.ProjectName.Contains(SearchTxb.Text)
                                                                                      || i.Supervisors.FullName == SearchTxb.Text || i.Supervisors.FullName.Contains(SearchTxb.Text)).ToList();
                    }
                }
            }
        }
    }
}
