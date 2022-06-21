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
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        var reservation = new Reservation()
                        {
                            idt = 4,
                            day = DateTime.Now.Date,
                            time = new TimeSpan(10, 15, 30),
                            namber = 3,
                            idk = 2
                        };

                        db.Reservations.Add(reservation);
                        db.SaveChanges();

                    }

                    // https://www.researchgate.net/profile/Muhammad-Iqbal-274/publication/322250414/figure/fig3/AS:579066325864448@1515071578177/A-SQL-injection-attack.png
                    //contr.Add("Reservations", "" + textBoxIDTable.Text + "', '" + textBoxDay.Text + "', '" + textBoxTime.Text + "', '" + textBoxNamber.Text + "', '" + textBoxIDK + "" );
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


            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                var reservations = db.Reservations.ToList();



                /*
                 https://www.plukasiewicz.net/EFCore/EFCoreDSDelete
                 https://dirask.com/posts/C-przyk%C5%82ad-u%C5%BCycia-Entity-Framework-wraz-z-Microsoft-SQL-Server-jmJdN1
                 https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
                 https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes/key-attribute
                 https://dirask.com/posts/C-NET-przekonwertuj-DateTime-na-ISO-8601-D7BwA1
                 https://stackoverflow.com/questions/12460987/how-can-i-bind-datagrid-to-some-properties-of-a-class-in-wpf
                 https://pl.wikipedia.org/wiki/Notacja_w%C4%99gierska
                
                 https://dirask.com/posts/C-NET-przekonwertuj-DateTime-na-ISO-8601-D7BwA1

                 
                 
                 */

                // https://stackoverflow.com/questions/46642645/datagridtextcolumn-datetime-binding-date-format

                this.grdReservations.ItemsSource = reservations;





                foreach (var reservation in reservations)
                {

                    var block1 = new Border()
                    {
                        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                        BorderThickness = new Thickness(1),
                        Width = 100,
                        Child = new TextBlock() { Text = Convert.ToString(reservation.idk) }
                    };
                    var block2 = new Border()
                    {
                        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                        BorderThickness = new Thickness(1),
                        Width = 100,
                        Child = new TextBlock() { Text = Convert.ToString(reservation.idk) }
                    };
                    var block3 = new Border()
                    {
                        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                        BorderThickness = new Thickness(1),
                        Width = 100,
                        Child = new TextBlock() { Text = Convert.ToString(reservation.day.ToString("yyyy-MM-dd")) }
                    };
                    var block4 = new Border()
                    {
                        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                        BorderThickness = new Thickness(1),
                        Width = 100,
                        Child = new TextBlock() { Text = Convert.ToString(reservation.idk) }

                    };
                    var block5 = new Border()
                    {
                        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                        BorderThickness = new Thickness(1),
                        Width = 100,
                        Child = new TextBlock() { Text = Convert.ToString(reservation.day.ToString("HH:mm")) }

                    };
                    var block6 = new Border()
                    {
                        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                        BorderThickness = new Thickness(1),
                        Width = 100,
                        Child = new TextBlock() { Text = Convert.ToString(reservation.namber) }

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

            //DataTable usersTable = contr.Get("Reservations", "*");
            //foreach (DataRow row in usersTable.Rows)
            //{

            //    var block1 = new Border()
            //    {
            //        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
            //        BorderThickness = new Thickness(1),
            //        Width = 100,
            //        Child = new TextBlock() { Text = Convert.ToString(row[0]) }
            //    };
            //    var block2 = new Border()
            //    {
            //        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
            //        BorderThickness = new Thickness(1),
            //        Width = 100,
            //        Child = new TextBlock() { Text = Convert.ToString(row[1]) }
            //    };
            //    var block3 = new Border()
            //    {
            //        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
            //        BorderThickness = new Thickness(1),
            //        Width = 100,
            //        Child = new TextBlock() { Text = Convert.ToString(row[2]) }
            //    };
            //    var block4 = new Border()
            //    {
            //        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
            //        BorderThickness = new Thickness(1),
            //        Width = 100,
            //        Child = new TextBlock() { Text = Convert.ToString(row[3]) }

            //    };
            //    var block5 = new Border()
            //    {
            //        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
            //        BorderThickness = new Thickness(1),
            //        Width = 100,
            //        Child = new TextBlock() { Text = Convert.ToString(row[4]) }

            //    };
            //    var block6 = new Border()
            //    {
            //        BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
            //        BorderThickness = new Thickness(1),
            //        Width = 100,
            //        Child = new TextBlock() { Text = Convert.ToString(row[5]) }

            //    };
            //    var stack = new StackPanel() { Orientation = Orientation.Horizontal };
            //    stack.Children.Add(block1);
            //    stack.Children.Add(block2);
            //    stack.Children.Add(block3);
            //    stack.Children.Add(block4);
            //    stack.Children.Add(block5);
            //    stack.Children.Add(block6);
            //    usersStackTable.Children.Add(stack);
            //}


        }

        private void itemEdit_Click(object sender, RoutedEventArgs e)
        {
            Reservation selectedReservation = this.grdReservations.SelectedItem as Reservation;

            if (selectedReservation != null)
            {
                MessageBox.Show("Edit: idr=" + selectedReservation.idr);
            }
        }

        private void itemRemove_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Remove");
        }
    }
}
