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
using user_addr.Model;
using user_addr.ViewModel;

namespace user_addr.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCountry.xaml
    /// </summary>
    public partial class WindowCountry : Window
    {
        public WindowCountry()
        {
            InitializeComponent();

            CountryViewModel vmCountry = new CountryViewModel();
            lvCountry.ItemsSource = vmCountry.ListCountry;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CountryViewModel vmCountry = new CountryViewModel();
            WindowNewCountry wnCountry = new WindowNewCountry
            {
                Title = "Новая страна",
                Owner = this
            };
            int maxIdCountry = vmCountry.MaxId() + 1;
            Country country = new Country
            {
                Id = maxIdCountry
            };
            wnCountry.DataContext = country;
            if (wnCountry.ShowDialog() == true)
            {
                vmCountry.ListCountry.Add(country);
                lvCountry.ItemsSource = vmCountry.ListCountry;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
