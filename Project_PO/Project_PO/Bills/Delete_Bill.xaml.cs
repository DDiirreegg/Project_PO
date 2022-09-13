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
    /// Логика взаимодействия для Delete_Bill.xaml
    /// </summary>
    public partial class Delete_Bill : Window
    {
        public Delete_Bill()
        {
            InitializeComponent();
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {

                this.cbBBill.ItemsSource = db.Bill.Select(i => i.idbill).ToList();
            }
        }

        private void cancelBill_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void delBill_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (cbBBill.SelectedValue == null)
                {
                    MessageBox.Show("Please, choose bill");
                }
                else
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        this.cbBBill.ItemsSource = db.Bill.Select(i => i.idbill).ToList();
                        var selectedValue = (cbBBill.SelectedValue);                        
                        var iteamToDel = db.Bill.SingleOrDefault(x => x.idbill == (int)selectedValue); ;
                        db.Bill.Remove(iteamToDel);
                        db.SaveChanges();

                    }


                    MessageBox.Show("Successfully");
                    Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to delete bill"); ;
            }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
    
}
