using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.ViewModel;

namespace user_addr.Model
{
    public class Address
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Person { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Office { get; set; }
        public Address() { }

        public Address(int id, int cityId, string person, string street, string building, string office)
        {
            this.Id = id;
            this.CityId = cityId;
            this.Person = person;
            this.Street = street;
            this.Building = building;
            this.Office = office;
        }

        public Address CopyFromAddressDPO(AddressDPO a)
        {
            CityViewModel vmCity = new CityViewModel();
            int cityId = 0;
            foreach (var c in vmCity.ListCity)
            {
                if (a.City == c.NameCity)
                {
                    cityId = c.Id;
                    break;
                }
            }
            if (cityId != 0)
            {
                this.Id = a.Id;
                this.CityId = cityId;
                this.Person = a.Person;
                this.Street = a.Street;
                this.Building = a.Building;
                this.Office = a.Office;
            }
            return this;
        }

    }
}
