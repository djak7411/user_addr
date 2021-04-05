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
        public WindowCity()
        {
            InitializeComponent();

            CityViewModel vmCity = new CityViewModel();
            RegionViewModel vmRegion = new RegionViewModel();
            List<Region> regions = new List<Region>();
            foreach (Region r in vmRegion.ListRegion)
            {
                regions.Add(r);
            }

            ObservableCollection<CityDPO> cities = new ObservableCollection<CityDPO>();
            FindRegion finder;
            foreach (var c in vmCity.ListCity)
            {
                finder = new FindRegion(c.RegionId);
                Region reg = regions.Find(new Predicate<Region>(finder.RegionPredicate));
                cities.Add(new CityDPO
                {
                    Id = c.Id,
                    NameCity= c.NameCity,
                    Region = reg.NameRegion,
                });
            }
            lvCity.ItemsSource = cities;
        }
    }
}
