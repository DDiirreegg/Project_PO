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
    /// Логика взаимодействия для DeletAnyDishFromMenu.xaml
    /// </summary>
    public partial class DeletAnyDishFromMenu : Window
    {
        public DeletAnyDishFromMenu()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void delDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxDelDish.Text == string.Empty)
                {
                    MessageBox.Show("Inputs is empty!");
                }
                else
                {
                    using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
                    {

                        var iteamToDel = db.Menu.SingleOrDefault(x => x.iddish == Int32.Parse(textBoxDelDish.Text)); ;
                        db.Menu.Remove(iteamToDel);
                        db.SaveChanges();

                    }


                    MessageBox.Show("Successfully");
                    Close();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Unable to delete waiter"); ;
            }
        }

        private void cancleDel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
