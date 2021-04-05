using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_addr.Model
{
    class Country
    {
        public int Id { get; set; }
        public string CountryFull { get; set; }
        public string CountryShort { get; set; }

        public Country() { }

        public Country(int id, string countryFull, string countryShort)
        {
            this.Id = id;
            this.CountryFull = countryFull;
            this.CountryShort = countryShort;
        }
    }
}
