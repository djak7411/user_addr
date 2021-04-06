using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.ViewModel;

namespace user_addr.Model
{
    public class Region
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

        public Region CopyFromRegionDPO(RegionDPO r)
        {
            CountryViewModel vmCountry = new CountryViewModel();
            int countryId = 0;
            foreach(var c in vmCountry.ListCountry)
            {
                if(r.Country == c.CountryShort)
                {
                    countryId = c.Id;
                    break;
                }
            }
            if(countryId != 0)
            {
                this.Id = r.Id;
                this.CountryId = countryId;
                this.NameRegion = r.NameRegion;
            }
            return this;
        }

    }
}
