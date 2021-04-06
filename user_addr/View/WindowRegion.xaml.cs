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
        private static RegionViewModel vmRegion = new RegionViewModel();
        private static ObservableCollection<RegionDPO> regionsDPO = new ObservableCollection<RegionDPO>();
        private static CountryViewModel vmCountry = new CountryViewModel();
        private static List<Country> countries = vmCountry.ListCountry.ToList();
        public WindowRegion()
        {
            InitializeComponent();
            if (regionsDPO.Count == 0)
            {
                foreach (var region in vmRegion.ListRegion)
                {
                    RegionDPO r = new RegionDPO();
                    r = r.CopyFromRegion(region);
                    regionsDPO.Add(r);
                }
            }
            lvRegion.ItemsSource = regionsDPO;
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            RegionDPO region = (RegionDPO)lvRegion.SelectedItem;
            if (region != null)
            {
                MessageBoxResult result = MessageBox.Show($"Удалить данные региона {region.NameRegion}?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    regionsDPO.Remove(region);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать регион для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRegion wnRegion = new WindowNewRegion
            {
                Title = "Редактирование региона",
                Owner = this
            };

            RegionDPO regDPO = (RegionDPO)lvRegion.SelectedValue;
            RegionDPO tempRegDPO;
            if(regDPO != null)
            {
                tempRegDPO = regDPO.ShallowCopy();
                wnRegion.DataContext = tempRegDPO;
                wnRegion.CbCountry.ItemsSource = countries;
                wnRegion.CbCountry.Text = tempRegDPO.Country;
                if(wnRegion.ShowDialog() == true)
                {
                    Country c = (Country)wnRegion.CbCountry.SelectedValue;
                    regDPO.Country = c.CountryShort;
                    regDPO.NameRegion = tempRegDPO.NameRegion;

                    lvRegion.ItemsSource = null;
                    lvRegion.ItemsSource = regionsDPO;

                    FindRegion finder = new FindRegion(regDPO.Id);
                    List<Region> listRegion = vmRegion.ListRegion.ToList();
                    Region r = listRegion.Find(new Predicate<Region>(finder.RegionPredicate));
                    r = r.CopyFromRegionDPO(regDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать регион для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRegion wnRegion = new WindowNewRegion
            {
                Title = "Новый регион",
                Owner = this
            };
            int maxIdRegion = vmRegion.MaxId() + 1;

            RegionDPO region = new RegionDPO
            {
                Id = maxIdRegion
            };
            wnRegion.DataContext = region;
            wnRegion.CbCountry.ItemsSource = countries;

            if (wnRegion.ShowDialog() == true)
            {
                Country c = (Country)wnRegion.CbCountry.SelectedValue;
                region.Country = c.CountryShort;
                regionsDPO.Add(region);

                Region r = new Region();
                r = r.CopyFromRegionDPO(region);
                vmRegion.ListRegion.Add(r);
            }
        }
    }
}
