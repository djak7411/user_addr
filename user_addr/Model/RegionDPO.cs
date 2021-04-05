using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_addr.Model
{
    public class RegionDPO
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string NameRegion { get; set; }

        public RegionDPO() { }

        public RegionDPO(int id, string country, string nameRegion)
        {
            this.Id = id;
            this.Country = country;
            this.NameRegion = nameRegion;
        }

    }
}
