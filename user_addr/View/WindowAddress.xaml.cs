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
    /// Логика взаимодействия для WindowAddress.xaml
    /// </summary>
    public partial class WindowAddress : Window
    {
        public WindowAddress()
        {
            InitializeComponent();

            AddressViewModel vmAddress = new AddressViewModel();
            CityViewModel vmCity = new CityViewModel();
            List<City> cities = new List<City>();
            foreach(City c in vmCity.ListCity)
            {
                cities.Add(c);
            }

            ObservableCollection<AddressDPO> addresses = new ObservableCollection<AddressDPO>();
            FindCity finder;
            foreach(var a in vmAddress.ListAddress)
            {
                finder = new FindCity(a.CityId);
                City cit = cities.Find(new Predicate<City>(finder.CityPredicate));
                addresses.Add(new AddressDPO
                {
                    Id = a.Id,
                    City = cit.NameCity,
                    Person = a.Person,
                    Street = a.Street,
                    Building = a.Building,
                    Office = a.Office
                });
            }
            lvAddress.ItemsSource = addresses;
        }

    }
}
