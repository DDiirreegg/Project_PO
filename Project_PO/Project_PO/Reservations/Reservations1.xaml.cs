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

        private void BtM_Click(object sender, RoutedEventArgs e)
        {
            //Не забудь сделать выход в меню для админа!!!!!!!!!!!!!!!!!!!!!
            MainForm window = new MainForm();
            window.Show();
            this.Close();


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
                            idt = Int32.Parse(textBoxIDTable.Text),
                            day = DateTime.Parse(textBoxDay.Text),
                            time = TimeSpan.Parse(textBoxTime.Text),
                            namber = Int32.Parse(textBoxNamber.Text),
                            idk = Int32.Parse(textBoxIDK.Text),                              
                        };

                        db.Reservations.Add(reservation);
                        db.SaveChanges();

                    }                     
                    MessageBox.Show("Successfully");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to add reservation");
            }
            showAllUsers();


        }

        
        private void DelReserv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxIDReserv.Text == string.Empty)
                {
                    MessageBox.Show("Inputs is empty!");
                }
                else
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {

                        var itemToRemove = db.Reservations.SingleOrDefault(x => x.idr == Int32.Parse(textBoxIDReserv.Text)); ;
                        db.Reservations.Remove(itemToRemove);
                        db.SaveChanges();

                    }

                    
                    MessageBox.Show("Successfully");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to delete waiter"); ;
            }
            showAllUsers();
        }
        void showAllUsers()
        {         
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                var reservations = db.Reservations.ToList();                                   
                this.grdReservations.ItemsSource = reservations;

            }

        }

        private void itemEdit_Click(object sender, RoutedEventArgs e)
        {
            UpdateReservtion window10 = new UpdateReservtion();               
            window10.Show();
            
        }

        private void allResev_Click(object sender, RoutedEventArgs e)
        {
            showAllUsers();
        }

        private void todayReserv_Click(object sender, RoutedEventArgs e)
        {
            
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                var todayREserv = db.Reservations.Where(w => w.day == DateTime.Today).ToList();
                grdReservations.ItemsSource = todayREserv;

            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            showAllUsers();
        }
        private void Refresh1(object sender, RoutedEventArgs e)
        {
            showAllUsers();
        }

    }
}
