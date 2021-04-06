using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_addr.Model;

namespace user_addr.Helper
{
    class FindAddress
    {
        int id;
        public FindAddress(int id)
        {
            this.id = id;
        }

        public bool AddressPredicate(Address address)
        {
            return address.Id == id;
        }
    }
}
