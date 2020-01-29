using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh12GenericsAndCollections
{
    public class Book : IComparable<Book>
    {
        public int CompareTo(Book other)
        {
            throw new NotImplementedException();
        }
    }
}
