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

namespace user_addr.View
{
    /// <summary>
    /// Логика взаимодействия для WindowNewCity.xaml
    /// </summary>
    public partial class WindowNewCity : Window
    {
        public WindowNewCity()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
