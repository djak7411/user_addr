using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.ViewModel;

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

        public RegionDPO CopyFromRegion(Region region)
        {
            RegionDPO regDPO = new RegionDPO();
            CountryViewModel vmCountry = new CountryViewModel();
            string country = string.Empty;
            foreach(var c in vmCountry.ListCountry)
            {
                if(c.Id == region.CountryId)
                {
                    country = c.CountryShort;
                    break;
                }
            }
            if(country != string.Empty)
            {
                regDPO.Id = region.Id;
                regDPO.Country = country;
                regDPO.NameRegion = region.NameRegion;
            }
            return regDPO;
        }

        public RegionDPO ShallowCopy()
        {
            return (RegionDPO)this.MemberwiseClone();
        }

    }
}
