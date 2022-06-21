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
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window1 = new MainWindow();
            window1.Show();
            this.Close();
        }

        private void Button_Reservations_Click(object sender, RoutedEventArgs e)
        {
            Reservations1 window2 = new Reservations1();
            window2.Show();
            this.Close();
        }

        private void Button_Menu_Click(object sender, RoutedEventArgs e)
        {
            Menu window3 = new Menu();
            window3.Show();
            this.Close();
        }       

        private void Button_Bill_Click(object sender, RoutedEventArgs e)
        {
            Bill window4 = new Bill();
            window4.Show();
            this.Close();
        }
        private void Refresh(object sender, RoutedEventArgs e)
        {
            nameK.Content = DataBank.namek;
            snameK.Content = DataBank.snamek;
        }
    }
}
