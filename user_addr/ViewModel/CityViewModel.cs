using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.Model;

namespace user_addr.ViewModel
{
    public class CityViewModel
    {
        public ObservableCollection<City> ListCity { get; set; } = new ObservableCollection<City>();

        public CityViewModel()
        {
            this.ListCity.Add(
                new City
                {
                    Id = 1,
                    RegionId = 1,
                    NameCity = "Санкт-Петербург"
                } 
            );
            this.ListCity.Add(
                new City
                {
                    Id = 2,
                    RegionId = 2,
                    NameCity = "Москва"
                }    
            );

        }
    }
}
