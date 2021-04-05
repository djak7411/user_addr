using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_addr.Model
{
    class City
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string NameCity { get; set; }

        public City() { }

        public City(int id, int regionId, string nameCity)
        {
            this.Id = id;
            this.RegionId = regionId;
            this.NameCity = nameCity;
        }
    }
}
