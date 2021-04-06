using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using user_addr.Helper;
using user_addr.Model;
using user_addr.ViewModel;

namespace user_addr.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCity.xaml
    /// </summary>
    public partial class WindowCity : Window
    {
        private static CityViewModel vmCity = new CityViewModel();
        private static ObservableCollection<CityDPO> citiesDPO = new ObservableCollection<CityDPO>();
        private static RegionViewModel vmRegion = new RegionViewModel();
        private static List<Region> regions = vmRegion.ListRegion.ToList();
        public WindowCity()
        {
            InitializeComponent();
            if (citiesDPO.Count == 0)
            {
                foreach (var city in vmCity.ListCity)
                {
                    CityDPO c = new CityDPO();
                    c = c.CopyFromCity(city);
                    citiesDPO.Add(c);
                }
            }
            lvCity.ItemsSource = citiesDPO;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CityDPO city = (CityDPO)lvCity.SelectedItem;
            if (city != null)
            {
                MessageBoxResult result = MessageBox.Show($"Удалить данные города {city.NameCity}?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    citiesDPO.Remove(city);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать город для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCity wnCity = new WindowNewCity
            {
                Title = "Редактирование города",
                Owner = this
            };

            CityDPO citDPO = (CityDPO)lvCity.SelectedValue;
            CityDPO tempCitDPO;
            if (citDPO != null)
            {
                tempCitDPO = citDPO.ShallowCopy();
                wnCity.DataContext = tempCitDPO;
                wnCity.CbRegion.ItemsSource = regions;
                wnCity.CbRegion.Text = tempCitDPO.Region;
                if (wnCity.ShowDialog() == true)
                {
                    Region r = (Region)wnCity.CbRegion.SelectedValue;
                    citDPO.Region = r.NameRegion;
                    citDPO.NameCity = tempCitDPO.NameCity;

                    lvCity.ItemsSource = null;
                    lvCity.ItemsSource = citiesDPO;

                    FindCity finder = new FindCity(citDPO.Id);
                    List<City> listCity = vmCity.ListCity.ToList();
                    City c = listCity.Find(new Predicate<City>(finder.CityPredicate));
                    c = c.CopyFromCityDPO(citDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать город для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCity wnCity = new WindowNewCity
            {
                Title = "Новый город",
                Owner = this
            };
            int maxIdCity = vmCity.MaxId() + 1;

            CityDPO city = new CityDPO
            {
                Id = maxIdCity
            };
            wnCity.DataContext = city;
            wnCity.CbRegion.ItemsSource = regions;

            if (wnCity.ShowDialog() == true)
            {
                Region r = (Region)wnCity.CbRegion.SelectedValue;
                city.Region = r.NameRegion;
                citiesDPO.Add(city);

                City c = new City();
                c = c.CopyFromCityDPO(city);
                vmCity.ListCity.Add(c);
            }
        }
    }
}
