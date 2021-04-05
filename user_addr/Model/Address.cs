using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_addr.Model
{
    class Address
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
    }
}
