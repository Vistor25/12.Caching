using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using NorthwindLibrary;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace DBWorker
{
    public class DBWorkerRedis<T>
        where T : class
    {
        private ConnectionMultiplexer redis;
        private IDatabase db;

        public DBWorkerRedis(string localhost)
        {
            redis = ConnectionMultiplexer.Connect(localhost);
            db = redis.GetDatabase();
        }

        public List<T> GetValues()
        {
            var entities = this.GetObjectFromCache(typeof(T).ToString());

            if (entities == null)
            {
                using (var dbNorthwind = new Northwind())
                {
                    this.SetConfigurationProperties(dbNorthwind);
                    entities = dbNorthwind.Set<T>().ToList();
                    this.AddObjectToCache(entities);
                }
            }

            return (List<T>)entities;
        }

        private void SetConfigurationProperties(Northwind db)
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        private void AddObjectToCache(List<T> entities)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(IEnumerable<T>));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, entities);
            db.StringSet(typeof(T).ToString(), stream.ToArray());
        }

        private List<T> GetObjectFromCache(string key)
        {
            var obj = db.StringGet(key);

            if (obj as object == null)
            {
                return null;
            }

            DataContractSerializer serializer = new DataContractSerializer(typeof(IEnumerable<T>));
            return (List<T>)serializer.ReadObject(new MemoryStream(obj));
        }
    }
}
