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
        private CountryViewModel vmCountry = new CountryViewModel();
        public WindowCountry()
        {
            InitializeComponent();
            lvCountry.ItemsSource = vmCountry.ListCountry;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
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
            WindowNewCountry wnCountry = new WindowNewCountry
            {
                Title = "Новая страна",
                Owner = this
            };
            Country country = lvCountry.SelectedItem as Country;
            if (country != null)
            {
                Country tempCountry = country.ShallowCopy();
                wnCountry.DataContext = tempCountry;
                if(wnCountry.ShowDialog() == true)
                {
                    country.CountryFull = tempCountry.CountryFull;
                    country.CountryShort = tempCountry.CountryShort;
                    lvCountry.ItemsSource = null;
                    lvCountry.ItemsSource = vmCountry.ListCountry;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать страну для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Country country = (Country)lvCountry.SelectedItem;
            if(country != null)
            {
                MessageBoxResult result = MessageBox.Show($"Удалить данные страны {country.CountryShort}?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if(result == MessageBoxResult.OK)
                {
                    vmCountry.ListCountry.Remove(country);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать страну для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
