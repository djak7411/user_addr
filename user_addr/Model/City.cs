using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.ViewModel;

namespace user_addr.Model
{
    public class City
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

        public City CopyFromCityDPO(CityDPO c)
        {
            RegionViewModel vmRegion = new RegionViewModel();
            int regionId = 0;
            foreach (var r in vmRegion.ListRegion)
            {
                if (c.Region == r.NameRegion)
                {
                    regionId = r.Id;
                    break;
                }
            }
            if (regionId != 0)
            {
                this.Id = c.Id;
                this.RegionId = regionId;
                this.NameCity = c.NameCity;
            }
            return this;
        }
    }
}
