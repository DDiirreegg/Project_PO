﻿using System;
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
            if(DataBank.namek == "admin" && DataBank.snamek == "admin")
            {
                MainFormAdmin window1 = MainFormAdmin();
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

    }
}
