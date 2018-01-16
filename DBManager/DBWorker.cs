using NorthwindLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using NorthwindLibrary;

namespace DBWorker
{
    public class DBWorker<T>
        where T : class
    {
        private ObjectCache cache;

        public DBWorker()
        {
            cache = MemoryCache.Default;
        }

        public List<T> GetEntities()
        {
            var entities = cache.Get(typeof(T).ToString());

            if (entities == null)
            {
                using (var dbNorthwind = new Northwind())
                {
                    this.SetConfigurationProperties(dbNorthwind);
                    entities = dbNorthwind.Set<T>().ToList();

                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTimeOffset.Now.AddMonths(1);
                    cache.Set(typeof(T).ToString(), entities, policy);
                }
            }

            return (List<T>)entities;
        } 

        private void SetConfigurationProperties(Northwind db)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }
    }
}
