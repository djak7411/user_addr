using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.Model;

namespace user_addr.ViewModel
{
    class AddressViewModel
    {
        public ObservableCollection<Address> ListAddress { get; set; } = new ObservableCollection<Address>();
        
        public AddressViewModel()
        {
            this.ListAddress.Add(
                new Address
                {
                    Id = 1,
                    Person = "Иванов Иван",
                    CityId = 1,
                    Building = "14а",
                    Street = "пр. Невский",
                    Office = "13/12"
                }
            );
            this.ListAddress.Add(
                new Address
                {
                    Id = 2,
                    Person = "Петров Петр",
                    CityId = 2,
                    Building = "123",
                    Street = "Ленина",
                    Office = "144"
                }
            );
        }
    }
}
