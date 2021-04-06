using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.ViewModel;

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

        public CityDPO ShallowCopy()
        {
            return (CityDPO)this.MemberwiseClone();
        }

        public CityDPO CopyFromCity(City city)
        {
            CityDPO citDPO = new CityDPO();
            RegionViewModel vmRegion = new RegionViewModel();
            string region = string.Empty;
            foreach (var r in vmRegion.ListRegion)
            {
                if (r.Id == city.RegionId)
                {
                    region = r.NameRegion;
                    break;
                }
            }
            if (region != string.Empty)
            {
                citDPO.Id = city.Id;
                citDPO.Region = region;
                citDPO.NameCity = city.NameCity;
            }
            return citDPO;
        }
    }
}
