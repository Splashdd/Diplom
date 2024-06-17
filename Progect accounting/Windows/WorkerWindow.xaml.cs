using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Progect_accounting.Windows;
using Progect_accounting.Frames;

namespace Progect_accounting.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public WorkerWindow()
        {
            InitializeComponent();

            if (Authorization.Globals.Access != 1)
            {
                MainFrame.Navigate(new ProjectsInformation());
            }
            else
            {
                MainFrame.Navigate(new UsersInformation());
                menu.Visibility = Visibility.Hidden;
            }

            Manager.MainFrame = MainFrame;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Authorization Auth = new Authorization();
            Auth.Show();
            this.Close();
        }

        private void GoTo_Projects(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProjectsInformation());
        }

        private void GoTo_Groups(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GroupsInformation());
        }

        private void GoTo_Supervisors(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SupervisorInformation());
        }
    }
}
