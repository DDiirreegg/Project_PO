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
using System.Xml.Linq;

namespace Project_PO
{
    /// <summary>
    /// Логика взаимодействия для AddNewWaiter.xaml
    /// </summary>
    public partial class AddNewWaiter : Window
    {
        public AddNewWaiter()
        {
            InitializeComponent();            
        }       

        private void AddWaiter_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if(textBoxLogReg.Text == string.Empty && textBoxPassReg.Text == string.Empty && textBoxNameReg.Text == string.Empty && textBoxSNameReg.Text == string.Empty)
                {
                    MessageBox.Show("Some inputs are empty!");
                }
                else
                {

                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        var userAdd = new User()
                        {
                            Login = textBoxLogReg.Text,
                            pass = textBoxPassReg.Text,
                            namek = textBoxNameReg.Text,
                            snamek = textBoxSNameReg.Text,                            
                        };

                        db.Users.Add(userAdd);
                        db.SaveChanges();

                    }
                    MessageBox.Show("Successfully");
                    showAllUsers();
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
                if (textBoxIDel.Text == string.Empty)
                {
                    MessageBox.Show("Inputs is empty!");
                }
                else
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        var itemToDelet = db.Users.SingleOrDefault(z => z.IdK == Int32.Parse(textBoxIDel.Text)); ;
                        db.Users.Remove(itemToDelet);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Successfully");
                    showAllUsers();
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
            using ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING);
            var userlist = db.Users.ToList();
            this.grdNewUser.ItemsSource = userlist;
        }       

        private void BtM_Click(object sender, RoutedEventArgs e)
        {
            MainFormAdmin window6 = new MainFormAdmin();
            window6.Show();
            this.Close();
        }
        private void Refresh(object sender, RoutedEventArgs e)
        {
            showAllUsers();
        }

        private void grdNewUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showAllUsers();
        }

        private void RefreshTable_Click(object sender, RoutedEventArgs e)
        {
            showAllUsers();
        }

        private void IdetClick_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxIDel.Text == string.Empty)
                {
                    MessageBox.Show("You have not entered a waiter ID!");
                }
                if (textBoxLogReg.Text == string.Empty && textBoxPassReg.Text == string.Empty && textBoxNameReg.Text == string.Empty && textBoxSNameReg.Text == string.Empty)
                {
                    MessageBox.Show("Some inputs are empty!");
                }
                else
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        int numWD = Int32.Parse(textBoxIDel.Text);
                        var uRow = db.Users.Where(w => w.IdK == numWD).FirstOrDefault();
                        {
                            uRow.Login = textBoxLogReg.Text;
                            uRow.pass = textBoxPassReg.Text;
                            uRow.namek = textBoxNameReg.Text;
                            uRow.snamek = textBoxSNameReg.Text;
                        };

                        db.SaveChanges();

                    }
                    MessageBox.Show("Successfully");
                    showAllUsers();

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to update reservation");
            }
        }

        
    }
}
