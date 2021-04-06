using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.Model;

namespace user_addr.ViewModel
{
    class RegionViewModel
    {
        public ObservableCollection<Region> ListRegion { get; set; } = new ObservableCollection<Region>();

        public RegionViewModel()
        {
            this.ListRegion.Add(
                new Region
                {
                    Id = 1,
                    CountryId = 1,
                    NameRegion = "Санкт-Петербург"
                }    
            );
            this.ListRegion.Add(
                new Region
                {
                    Id = 2,
                    CountryId = 1,
                    NameRegion = "Москва"
                }    
            );
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListRegion)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                }
            }
            return max;
        }
    }
}
