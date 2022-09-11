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
using Project_PO;

namespace Project_PO
{
    /// <summary>
    /// Логика взаимодействия для UpdateReservtion.xaml
    /// </summary>
    public partial class UpdateReservtion : Window
    {
        public UpdateReservtion()
        {
            InitializeComponent();
        }

        private void UpdateReserv_Click(object sender, RoutedEventArgs e)  
        {
            try
            {
                if (textBoxIDReservUpd.Text == string.Empty)
                {
                    MessageBox.Show("You have not entered a reservation ID!");
                }
                if (textBoxIDTableUpd.Text == string.Empty && textBoxDayUpd.Text == string.Empty && textBoxTimeUpd.Text == string.Empty && textBoxNamberUpd.Text == string.Empty && textBoxIDKUpd.Text == string.Empty)
                {
                    MessageBox.Show("Some inputs are empty!");
                }
                else
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        int num = Int32.Parse(textBoxIDReservUpd.Text);
                        var uRow = db.Reservations.Where(w => w.idr == num).FirstOrDefault();
                        {
                            uRow.idt = Int32.Parse(textBoxIDTableUpd.Text);
                            uRow.day = DateTime.Parse(textBoxDayUpd.Text);
                            uRow.time = TimeSpan.Parse(textBoxTimeUpd.Text);
                            uRow.namber = Int32.Parse(textBoxNamberUpd.Text);
                            uRow.idk = Int32.Parse(textBoxIDKUpd.Text);
                        };
                        
                        db.SaveChanges();

                    }
                    MessageBox.Show("Successfully");
                    this.Close();
                    
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to update reservation");
            }
            
        }

        private void BackToReserv_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
