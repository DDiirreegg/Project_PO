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
    /// Логика взаимодействия для Add_Edit_Bill.xaml
    /// </summary>
    public partial class Add_Edit_Bill : Window
    {
        public Add_Edit_Bill()
        {
            InitializeComponent();
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                this.idBillToAddEdit.ItemsSource = db.Bill.Select(i => i.idbill).ToList();
                this.dishToAddEdit.ItemsSource = db.Menu.Select(k => k.namedish).ToList();
            }
        }
        private void addEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dishToAddEdit.SelectedValue == null)
            {
                MessageBox.Show("You don't select any dishes");
            }
            if (idBillToAddEdit.SelectedValue == null && dishToAddEdit.SelectedValue != null)
            {
                try
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        List<Menu> pizdec = db.Menu.Where(j => j.namedish == dishToAddEdit.Text).ToList();
                        var addNewBill = new Bill()
                        {
                            dishes = dishToAddEdit.Text,
                            sumbill = pizdec[0].costdish,
                        };
                        db.Bill.Add(addNewBill);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Successfully");
                    Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Unable to add new bill");
                }
            }
            if (idBillToAddEdit.SelectedValue != null && dishToAddEdit.SelectedValue != null)
            {
                try
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        List<Menu> pizdec = db.Menu.Where(j => j.namedish == dishToAddEdit.Text).ToList();
                        int num = Int32.Parse(idBillToAddEdit.Text);
                        var uRow = db.Bill.Where(w => w.idbill == num).FirstOrDefault();
                        {
                            string connect = uRow.dishes;
                            uRow.dishes = connect.Replace(" ", string.Empty) + ", " + dishToAddEdit.Text;
                            uRow.sumbill += pizdec[0].costdish;
                        };
                        db.SaveChanges();
                    }
                    MessageBox.Show("Successfully");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to add the dish in the bill");
                }
            }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void cancleAdd_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
