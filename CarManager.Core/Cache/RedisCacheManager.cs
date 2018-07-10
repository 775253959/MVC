using CarManager.Core.Config;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Cache
{
    public class RedisCacheManager:ICacheManager
    {
        readonly string redisConnectionString;
        readonly object redisConnectionLock = new object();


        public volatile ConnectionMultiplexer redisConnection;

        public RedisCacheManager(ApplicationConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.redisCacheConfig.ConnectionString))
            {
                throw new ArgumentException("redis config is empty");
            }
            this.redisConnectionString = config.redisCacheConfig.ConnectionString;
            this.redisConnection = GetRedisConnection();
        }

        private ConnectionMultiplexer GetRedisConnection()
        {
            if (this.redisConnection != null && redisConnection.IsConnected)
            {
                return redisConnection;
            }

            lock (this.redisConnectionLock)
            {
                if (this.redisConnection != null)
                {
                    redisConnection.Dispose();
                }

                this.redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
                
            }
            return this.redisConnection;
        }

        private T Deserialize<T>(byte[] value)
        {
            if (value == null)
            {
                return default(T);
            }
            else
            {
                var jsonString = Encoding.UTF8.GetString(value);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
            }
        }

        private byte[] Serialize(object item)
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public void Clear()
        {
            foreach (var endPoint in this.GetRedisConnection().GetEndPoints())
            {
                var server = this.GetRedisConnection().GetServer(endPoint);
                foreach (var item in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(item);
                }
            }
        }

        public bool Contains(string key)
        {
            return redisConnection.GetDatabase().KeyExists(key);
            
        }

        public T Get<T>(string key)
        {
            var value = redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                return Deserialize<T>(value);
            }
            else
            {
                return default(T);
            }
        }

        public void Remove(string key)
        {
            redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value != null)
            {
                redisConnection.GetDatabase().StringSet(key,Serialize(value),cacheTime);
            }
        }
    }
}
