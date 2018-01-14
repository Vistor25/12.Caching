using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ClassLibrary1
{
    public class Class2
    {
        private ConnectionMultiplexer redis;
        private IDatabase db;
        public Class2(string localhost)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
        }

        public int Fibonachi(int n)
        {
            if (n < 2)
            {
                return n;
            }



            if (db.StringGet(n.ToString()) != 0)
            {
                return (int)db.StringGet(n.ToString());
            }

            int number = Fibonachi(n - 1) + Fibonachi(n - 2);
            db.StringSet(n.ToString(), number);
            return number;
        }
    }
}
