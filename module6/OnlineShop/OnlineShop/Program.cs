using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDbContext())
            {
                // do stuff
            }
        }
    }
}
