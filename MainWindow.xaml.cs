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
using System.Data.SqlClient;
using System.Data;

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
        SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-MO07QQI;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

       bool loginChecker()
        {
            Conn.Open();
            string myQuery = "select login, pass, namek, snamek from Users";
            SqlDataAdapter da = new SqlDataAdapter(myQuery, Conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds, "Users");
            DataTable usersTable = ds.Tables["Users"];            
            foreach (DataRow row in usersTable.Rows)
            {
                if ((string)row["login"] == textBoxLogin.Text && (string)row["pass"] == passBox.Password)
                {
                    DataBank.namek = (string)row["namek"];
                    DataBank.snamek = (string)row["snamek"];
                    Conn.Close();
                    return true;
                }
            }
            Conn.Close();
            return false;
            

        }
        private void Button_login_Click(object sender, RoutedEventArgs e)
        {

            if (textBoxLogin.Text == "admin" && passBox.Password == "admin")
            {
                DataBank.namek = "admin";
                DataBank.snamek = "admin";
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








            /*string login = textBoxLogin.Text;
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
            }*/

        

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {        
            Close();
        }
    }
}
