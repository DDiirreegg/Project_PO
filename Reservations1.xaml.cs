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
using System.Windows.Shapes;

namespace Project_PO
{
    /// <summary>
    /// Логика взаимодействия для Reservations1.xaml
    /// </summary>
    public partial class Reservations1 : Window
    {
        public Reservations1()
        {
            InitializeComponent();
        }
        static string path = @"Data Source=DESKTOP-MO07QQI;Initial Catalog=Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        controllDataBase contr = new controllDataBase(path);

        private void BtM_Click(object sender, RoutedEventArgs e)
        {
            if(DataBank.namek == "admin" && DataBank.snamek == "admin")
            {
                MainFormAdmin window1 = new MainFormAdmin();
                window1.Show();
                this.Close();
            }
            else
            {
                MainForm window = new MainForm();
                window.Show();
                this.Close();
            }
            
        }
        public void Refresh(object sender, RoutedEventArgs e)
        {
            showAllUsers();
            nameK.Content = DataBank.namek;
            snameK.Content = DataBank.snamek;
        }

        private void AddReserv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxIDTable.Text == string.Empty && textBoxDay.Text == string.Empty && textBoxTime.Text == string.Empty && textBoxNamber.Text == string.Empty && textBoxIDK.Text == string.Empty)
                {
                    MessageBox.Show("Some inputs are empty!");
                }
                else
                {
                    contr.Add("Reservations", "" + textBoxIDTable.Text + "', '" + textBoxDay.Text + "', '" + textBoxTime.Text + "', '" + textBoxNamber.Text + "', '" + textBoxIDK + "" );
                    MessageBox.Show("Successfully");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to add waiter");
            }
            showAllUsers();


        }

        private void DelReserv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contr.Delete("Reservations", "idr", textBoxIDReserv.Text);
                MessageBox.Show("Delete is correct");
            }
            catch (Exception)
            {

                MessageBox.Show("Unable to delete waiter"); ;
            }
            showAllUsers();
        }
        void showAllUsers()
        {
            usersStackTable.Children.Clear();



            var HeaderBlock1 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Reservation ID", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock2 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Table ID", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock3 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Reservation date", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock4 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Reservation time", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock5 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Number of people", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock6 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Waiter ID", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var stackHeader = new StackPanel() { Orientation = Orientation.Horizontal, };
            stackHeader.Children.Add(HeaderBlock1);
            stackHeader.Children.Add(HeaderBlock2);
            stackHeader.Children.Add(HeaderBlock3);
            stackHeader.Children.Add(HeaderBlock4);
            stackHeader.Children.Add(HeaderBlock5);
            stackHeader.Children.Add(HeaderBlock6);
            usersStackTable.Children.Add(stackHeader);


            DataTable usersTable = contr.Get("Reservations", "*");
            foreach (DataRow row in usersTable.Rows)
            {

                var block1 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = Convert.ToString(row[0]) }
                };
                var block2 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = Convert.ToString(row[1]) }
                };
                var block3 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = Convert.ToString(row[2]) }
                };
                var block4 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = Convert.ToString(row[3]) }

                };
                var block5 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = Convert.ToString(row[4]) }

                };
                var block6 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = Convert.ToString(row[5]) }

                };
                var stack = new StackPanel() { Orientation = Orientation.Horizontal };
                stack.Children.Add(block1);
                stack.Children.Add(block2);
                stack.Children.Add(block3);
                stack.Children.Add(block4);
                stack.Children.Add(block5);
                stack.Children.Add(block6);
                usersStackTable.Children.Add(stack);
            }


        }
    }
}
