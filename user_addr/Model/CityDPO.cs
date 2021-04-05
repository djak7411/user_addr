using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_addr.Model
{
    public class CityDPO
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string NameCity { get; set; }

        public CityDPO() { }

        public CityDPO(int id, string region, string nameCity)
        {
            this.Id = id;
            this.Region = region;
            this.NameCity = nameCity;
        }
    }
}
