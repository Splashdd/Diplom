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
using Progect_accounting.Database;
using System.Data.Entity;

namespace Progect_accounting
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public static class Globals
        {
            public static int Access;
        }

        public Authorization()
        {
            InitializeComponent();
        }

        private void Entering(object sender, RoutedEventArgs e)
        {
            using (var db = new Project_accounting_DBEntities())
            {
                var auth = Project_accounting_DBEntities.GetContext().Users.AsNoTracking().FirstOrDefault(a => a.Login == loginTxb.Text && a.Password == passBox.Password);
                if (auth != null)
                {
                    Globals.Access = auth.Role_ID;
                    MessageBox.Show("Добро пожаловать!", "Приветствие", MessageBoxButton.OK);
                    WorkerWindow WW = new WorkerWindow();
                    WW.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Clean(object sender, RoutedEventArgs e)
        {
            loginTxb.Text = string.Empty;
            passBox.Password = string.Empty;
        }
    }
}
