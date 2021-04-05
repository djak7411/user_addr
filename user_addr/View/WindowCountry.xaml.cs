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
    }
}
