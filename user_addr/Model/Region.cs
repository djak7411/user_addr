using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_addr.Model
{
    class Region
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string NameRegion { get; set; }

        public Region() { }

        public Region(int id, int countryId, string nameRegion)
        {
            this.Id = id;
            this.CountryId = countryId;
            this.NameRegion = nameRegion;
        }

    }
}
