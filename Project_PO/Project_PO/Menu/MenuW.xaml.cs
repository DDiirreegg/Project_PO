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
using System.Windows.Shapes;

namespace Project_PO
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class MenuW : Window
    {
        public MenuW()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                this.grdMenu.ItemsSource = db.Menu.ToList();
            }
        }
        void showAllUsers()
        {
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                var menuT = db.Menu.ToList();
                this.grdMenu.ItemsSource = menuT;

            }

        }

        private void addDish_Click(object sender, RoutedEventArgs e)
        {
             AddNewDishInMenu window14 = new AddNewDishInMenu();
            window14.Show();
        }

        private void deletDish_Click(object sender, RoutedEventArgs e)
        {
            DeletAnyDishFromMenu window13 = new DeletAnyDishFromMenu();
            window13.Show();
        }

        private void editDish_Click(object sender, RoutedEventArgs e)
        {
            EditSomeDishinMenu window15 = new EditSomeDishinMenu();
            window15.Show();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainForm window11 = new MainForm();
            window11.Show();
            this.Close();
        }

        private void RefreshDish_Click(object sender, RoutedEventArgs e)
        {
            showAllUsers();
        }
    }
}
