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
    /// Логика взаимодействия для Bill.xaml
    /// </summary>
    public partial class BillWindow : Window
    {
        public BillWindow()
        {
            InitializeComponent();


            //this.btnGoBack.Content = "Go back test!!!";

            ////this.grdBills
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ProjectContext db = new ProjectContext(ProjectConfig.CONNECTION_STRING))
            {
                this.grdBills.ItemsSource = db.Bills.ToList();
            }
        }
    }
}