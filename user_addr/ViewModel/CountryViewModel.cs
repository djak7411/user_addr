using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.Model;

namespace user_addr.ViewModel
{
    class CountryViewModel
    {
        public ObservableCollection<Country> ListCountry { get; set; } = new ObservableCollection<Country>();

        public CountryViewModel()
        {
            this.ListCountry.Add(
                new Country
                {
                    Id = 1,
                    CountryFull = "Российская Федерация",
                    CountryShort = "РФ"
                }    
            );
        }
    }
}
