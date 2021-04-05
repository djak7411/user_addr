using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.Model;

namespace user_addr.Helper
{
    public class FindCity
    {
        int id;
        public FindCity(int id)
        {
            this.id = id;
        }

        public bool CityPredicate(City city)
        {
            return city.Id == id;
        }
    }
}
