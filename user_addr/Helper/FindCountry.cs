using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.Model;

namespace user_addr.Helper
{
    public class FindCountry
    {
        int id;
        public FindCountry(int id)
        {
            this.id = id;
        }

        public bool CountryPredicate(Country country)
        {
            return country.Id == id;
        }
    }
}
