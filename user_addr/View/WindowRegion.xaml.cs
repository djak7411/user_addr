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
    /// Логика взаимодействия для WindowRegion.xaml
    /// </summary>
    public partial class WindowRegion : Window
    {
        public WindowRegion()
        {
            InitializeComponent();

            RegionViewModel vmRegion = new RegionViewModel();
            CountryViewModel vmCountry = new CountryViewModel();
            List<Country> countries = new List<Country>();
            foreach (Country c in vmCountry.ListCountry)
            {
                countries.Add(c);
            }

            ObservableCollection<RegionDPO> regions = new ObservableCollection<RegionDPO>();
            FindCountry finder;
            foreach (var r in vmRegion.ListRegion)
            {
                finder = new FindCountry(r.CountryId);
                Country cnt = countries.Find(new Predicate<Country>(finder.CountryPredicate));
                regions.Add(new RegionDPO
                {
                    Id = r.Id,
                    Country = cnt.CountryShort,
                    NameRegion = r.NameRegion,
                });
            }
            lvRegion.ItemsSource = regions;
        }

    }
}
