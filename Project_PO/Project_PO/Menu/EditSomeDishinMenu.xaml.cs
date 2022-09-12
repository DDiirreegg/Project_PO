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
    /// Логика взаимодействия для EditSomeDishinMenu.xaml
    /// </summary>
    public partial class EditSomeDishinMenu : Window
    {
        public EditSomeDishinMenu()
        {
            InitializeComponent();
        }
        private void cancleEdit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void editDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxIDDish.Text == string.Empty)
                {
                    MessageBox.Show("You have not entered a dish ID!");
                }
                if (textBoxNameDish.Text == string.Empty && textBoxCostDish.Text == string.Empty)
                {
                    MessageBox.Show("Some inputs are empty!");
                }
                else
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {
                        int num = Int32.Parse(textBoxIDDish.Text);
                        var uRow = db.Menu.Where(w => w.iddish == num).FirstOrDefault();
                        {
                            uRow.namedish = textBoxNameDish.Text;
                            uRow.costdish = Int32.Parse(textBoxCostDish.Text);
                            uRow.description = textBoxDescrip.Text;
                        };

                        db.SaveChanges();

                    }
                    MessageBox.Show("Successfully");
                    this.Close();

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to edit dish");
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        
    }
}
