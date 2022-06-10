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

namespace Project_PO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_login_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string pass = passBox.Password;

            if(login.Length < 7)
            {
                textBoxLogin.ToolTip = "Field entered incorrectly";
                textBoxLogin.Background = Brushes.MediumVioletRed;
            }
            else if(pass.Length < 5)
            {
                passBox.ToolTip = "Field entered incorrectly";
                passBox.Background = Brushes.MediumVioletRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                passBox.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.Background = Brushes.Transparent;

                MessageBox.Show("all is correct");
            }

        }

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
