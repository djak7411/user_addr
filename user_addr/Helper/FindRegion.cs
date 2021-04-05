using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.Model;

namespace user_addr.Helper
{
    public class FindRegion
    {
        int id;
        public FindRegion(int id)
        {
            this.id = id;
        }

        public bool RegionPredicate(Region region)
        {
            return region.Id == id;
        }
    }
}
