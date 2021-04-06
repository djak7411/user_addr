using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.ViewModel;

namespace user_addr.Model
{
    public class AddressDPO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Person { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Office { get; set; }
        public AddressDPO() { }

        public AddressDPO(int id, string cityId, string person, string street, string building, string office)
        {
            this.Id = id;
            this.City = cityId;
            this.Person = person;
            this.Street = street;
            this.Building = building;
            this.Office = office;
        }

        public AddressDPO ShallowCopy()
        {
            return (AddressDPO)this.MemberwiseClone();
        }

        public AddressDPO CopyFromAddress(Address address)
        {
            AddressDPO adrDPO = new AddressDPO();
            CityViewModel vmCity = new CityViewModel();
            string city = string.Empty;
            foreach (var c in vmCity.ListCity)
            {
                if (c.Id == address.CityId)
                {
                    city = c.NameCity;
                    break;
                }
            }
            if (city != string.Empty)
            {
                adrDPO.Id = address.Id;
                adrDPO.City = city;
                adrDPO.Person = address.Person;
                adrDPO.Street = address.Street;
                adrDPO.Building = address.Building;
                adrDPO.Office = address.Office;
            }
            return adrDPO;
        }
    }
}
