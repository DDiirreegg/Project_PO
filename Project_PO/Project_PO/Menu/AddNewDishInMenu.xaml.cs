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
    /// Логика взаимодействия для AddNewDishInMenu.xaml
    /// </summary>
    public partial class AddNewDishInMenu : Window
    {
        public AddNewDishInMenu()
        {
            InitializeComponent();
        }

        private void addDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxNameDish.Text == string.Empty && textBoxCostDish.Text == string.Empty)
                {
                    MessageBox.Show("Name or Cost are empty!");
                }
                else
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        var adddish = new Menu()
                        {
                            namedish = textBoxNameDish.Text,
                            costdish = Int32.Parse(textBoxCostDish.Text),
                            description = textBoxDescrip.Text,
                            
                        };

                        db.Menu.Add(adddish);
                        db.SaveChanges();

                    }
                    MessageBox.Show("Successfully");
                    Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to add dish");
            }
        }

        private void cancleAdd_Click(object sender, RoutedEventArgs e)
        {
                 Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
