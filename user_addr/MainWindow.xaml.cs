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
using System.Windows.Navigation;
using System.Windows.Shapes;
using user_addr.View;

namespace user_addr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int IdCountry { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Address_Click(object sender, RoutedEventArgs e)
        {
            WindowAddress wAddress = new WindowAddress();
            wAddress.Show();
        }

        private void City_Click(object sender, RoutedEventArgs e)
        {
            WindowCity wCity = new WindowCity();
            wCity.Show();
        }

        private void Country_Click(object sender, RoutedEventArgs e)
        {
            WindowCountry wCountry = new WindowCountry();
            wCountry.Show();
        }

        private void Region_Click(object sender, RoutedEventArgs e)
        {
            WindowRegion wRegion = new WindowRegion();
            wRegion.Show();
        }
    }
}
