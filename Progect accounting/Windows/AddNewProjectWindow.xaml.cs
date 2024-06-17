using Microsoft.Win32;
using Progect_accounting.Database;
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
using System.IO;

namespace Progect_accounting.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewProjectWindow.xaml
    /// </summary>
    public partial class AddNewProjectWindow : Window
    {
        private Projects _currentProject = new Projects();
        public AddNewProjectWindow(Projects selectedProject)
        {
            InitializeComponent();

            if (selectedProject != null)
            {
                _currentProject = selectedProject;
                SelectFileBtn.Background = Brushes.LightGreen;
                SelectFileBtn.Content = "Изменить";
                AddBtn.Content = "Сохранить";
                windowTitle.Text = "Изменение работы";
                ProjTypeCB.SelectedIndex = _currentProject.ProjectType;
                MarkCB.Text = Convert.ToString(_currentProject.Mark);
            }

            DataContext = _currentProject;
            GroupsCB.ItemsSource = Project_accounting_DBEntities.GetContext().Groups.ToList();
            SupervCB.ItemsSource = Project_accounting_DBEntities.GetContext().Supervisors.ToList();
        }

        private void Select_Files(object sender, RoutedEventArgs e)
        {
            if (_currentProject.Files != null)
            {
                _currentProject.Files = null;
            }
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ZIP архив(*.zip)|*.zip";
            openFileDialog.ShowDialog();
            try
            {
                byte[] file_bytes = File.ReadAllBytes(openFileDialog.FileName);
                _currentProject.Files = file_bytes;
                SelectFileBtn.Background = Brushes.LightGreen;
                SelectFileBtn.Content = "Выбранно";
            }
            catch
            {
                
            }
        }

        private void Add_Project(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (GroupsCB.SelectedValue == null)
                Errors.AppendLine("Укажите группу!");
            if (FullNStudTB.Text == "")
                Errors.AppendLine("Укажите ФИО студента!");
            if (ProjTypeCB.SelectedValue == null)
                Errors.AppendLine("Укажите тип работы!");
            if (ProjNTB.Text == "")
                Errors.AppendLine("Укажите название!");
            if (SupervCB.SelectedValue == null)
                Errors.AppendLine("Укажите ФИО руководителя!");
            if (CompDateDP.SelectedDate == null)
                Errors.AppendLine("Укажите дату выполнения!");
            if (MarkCB.SelectedValue == null)
                Errors.AppendLine("Укажите оценку!");
            if (SelectFileBtn.Background != Brushes.LightGreen)
                Errors.AppendLine("Не указанн файл!");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString(), "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _currentProject.ProjectType = ProjTypeCB.SelectedIndex;
            _currentProject.Mark = Convert.ToInt16(MarkCB.Text);

            if (_currentProject.ID == 0)
            {
                Project_accounting_DBEntities.GetContext().Projects.Add(_currentProject);
            }

            try
            {
                Project_accounting_DBEntities.GetContext().SaveChanges();
                MessageBox.Show("Проект сохранен", "Успех", MessageBoxButton.OK);
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
