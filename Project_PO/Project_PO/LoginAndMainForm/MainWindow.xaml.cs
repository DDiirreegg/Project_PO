using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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








            //using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            //{

            //    var bills = db.Bills.ToList();

            //    Console.WriteLine();
            //}






        }
        SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-MO07QQI;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        bool loginChecker()
        {
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                var user = db.Users
                    .Where(u => u.Login == textBoxLogin.Text && u.pass == passBox.Password)
                    .FirstOrDefault();

                return user != null;
            }

            
        }
        private void Button_login_Click(object sender, RoutedEventArgs e)
        {

            if (textBoxLogin.Text == "admin" && passBox.Password == "admin")
            {                    
                MainFormAdmin window1 = new MainFormAdmin();
                window1.Show();
                this.Close();
            }
            else if (loginChecker())
            {
                MainForm window = new MainForm();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Doesn't correct or something else problems");
            }

        }        

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
