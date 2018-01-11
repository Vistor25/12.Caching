using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.Caching;

namespace ClassLibrary1
{
    public class Class1
    {
        MemoryCache cache = MemoryCache.Default;
        public int Fibonachi(int n)
        {
            if (n < 2)
            {
                return n;
            }

           
            
            if(cache.Get(n.ToString()) != null)
            {
                return (int)cache.Get(n.ToString());
            }
           
            int number = Fibonachi(n - 1) + Fibonachi(n - 2);
            cache.Add(n.ToString(), number, ObjectCache.InfiniteAbsoluteExpiration);
            return number;
        }
    }
}
