using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для Bill.xaml
    /// </summary>
    public partial class BillWindow : Window
    {
        public BillWindow()
        {
            InitializeComponent();            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            showAllUsers();
        }
                

        private void grdBills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showAllUsers();
        }
        void showAllUsers()
        {
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                var billInList = db.Bill.ToList();   
                this.grdBills.ItemsSource = billInList;

            }
        }        

        private void BtM_Click(object sender, RoutedEventArgs e)
        {
            MainForm window1 = new MainForm();
            window1.Show();
            this.Close();
        }

        private void DelReserv_Click(object sender, RoutedEventArgs e)
        {
            Delete_Bill window2 = new Delete_Bill();
            window2.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            showAllUsers();
        }

        private void AddReserv_Click(object sender, RoutedEventArgs e)
        {
            Add_Edit_Bill window3 = new Add_Edit_Bill();
            window3.Show();
        }
    }
}
