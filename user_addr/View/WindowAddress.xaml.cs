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
    /// Логика взаимодействия для WindowAddress.xaml
    /// </summary>
    public partial class WindowAddress : Window
    {
        public WindowAddress()
        {
            InitializeComponent();

            AddressViewModel vmAddress = new AddressViewModel();
            lvAddress.ItemsSource = vmAddress.ListAddress;
        }
    }
}
