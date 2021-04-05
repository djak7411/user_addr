using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_addr.Model
{
    class AddressDPO
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
    }
}
