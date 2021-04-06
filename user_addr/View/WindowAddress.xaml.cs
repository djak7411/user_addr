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
        private static AddressViewModel vmAddress = new AddressViewModel();
        private static ObservableCollection<AddressDPO> addressesDPO = new ObservableCollection<AddressDPO>();
        private static CityViewModel vmCity = new CityViewModel();
        private static List<City> cities = vmCity.ListCity.ToList();
        public WindowAddress()
        {
            InitializeComponent();
            if (addressesDPO.Count == 0)
            {
                foreach (var adr in vmAddress.ListAddress)
                {
                    AddressDPO a = new AddressDPO();
                    a = a.CopyFromAddress(adr);
                    addressesDPO.Add(a);
                }
            }
            lvAddress.ItemsSource = addressesDPO;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AddressDPO address = (AddressDPO)lvAddress.SelectedItem;
            if (address != null)
            {
                MessageBoxResult result = MessageBox.Show($"Удалить данные адреса {address.Person}?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    addressesDPO.Remove(address);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать адрес для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAddress wnAddress = new WindowNewAddress
            {
                Title = "Редактирование адреса",
                Owner = this
            };

            AddressDPO adrDPO = (AddressDPO)lvAddress.SelectedValue;
            AddressDPO tempAdrDPO;
            if (adrDPO != null)
            {
                tempAdrDPO = adrDPO.ShallowCopy();
                wnAddress.DataContext = tempAdrDPO;
                wnAddress.CbCity.ItemsSource = cities;
                wnAddress.CbCity.Text = tempAdrDPO.City;
                if (wnAddress.ShowDialog() == true)
                {
                    City c = (City)wnAddress.CbCity.SelectedValue;
                    adrDPO.City = c.NameCity;
                    adrDPO.Person = tempAdrDPO.Person;
                    adrDPO.Street = tempAdrDPO.Street;
                    adrDPO.Building = tempAdrDPO.Building;
                    adrDPO.Office = tempAdrDPO.Office;

                    lvAddress.ItemsSource = null;
                    lvAddress.ItemsSource = addressesDPO;

                    FindAddress finder = new FindAddress(adrDPO.Id);
                    List<Address> listAddress = vmAddress.ListAddress.ToList();
                    Address a = listAddress.Find(new Predicate<Address>(finder.AddressPredicate));
                    a = a.CopyFromAddressDPO(adrDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать регион для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAddress wnAddress = new WindowNewAddress
            {
                Title = "Новый адрес",
                Owner = this
            };
            int maxIdAddress = vmAddress.MaxId() + 1;

            AddressDPO address = new AddressDPO
            {
                Id = maxIdAddress
            };
            wnAddress.DataContext = address;
            wnAddress.CbCity.ItemsSource = cities;

            if (wnAddress.ShowDialog() == true)
            {
                City c = (City)wnAddress.CbCity.SelectedValue;
                address.City = c.NameCity;
                addressesDPO.Add(address);

                Address a = new Address();
                a = a.CopyFromAddressDPO(address);
                vmAddress.ListAddress.Add(a);
            }
        }
    }
}
