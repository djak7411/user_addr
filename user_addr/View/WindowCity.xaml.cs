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
        private CityViewModel vmCity = new CityViewModel();
        private ObservableCollection<CityDPO> citiesDPO = new ObservableCollection<CityDPO>();
        public WindowCity()
        {
            InitializeComponent();

            RegionViewModel vmRegion = new RegionViewModel();
            List<Region> regions = new List<Region>();
            foreach (Region r in vmRegion.ListRegion)
            {
                regions.Add(r);
            }

            FindRegion finder;
            foreach (var c in vmCity.ListCity)
            {
                finder = new FindRegion(c.RegionId);
                Region reg = regions.Find(new Predicate<Region>(finder.RegionPredicate));
                citiesDPO.Add(new CityDPO
                {
                    Id = c.Id,
                    NameCity= c.NameCity,
                    Region = reg.NameRegion,
                });
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
                MessageBox.Show("Необходимо выбрать страну для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
