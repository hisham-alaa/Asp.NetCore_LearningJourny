using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQ
{
    class MyComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
            => x?.UnitsInStock.CompareTo(y?.UnitsInStock)??0;
    }
}
