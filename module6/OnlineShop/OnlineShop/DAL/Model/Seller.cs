using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Model
{
    class Seller
    {
        public int SellerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
