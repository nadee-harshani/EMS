using System;
using System.Runtime.Caching;

namespace EmployeeManagementWeb.Services
{
    public class CacheManagementService
    {
        private static readonly ObjectCache cache = MemoryCache.Default;

        //Add to cache 
        public static void AddToCache(string key, object value, DateTimeOffset expiredTime)
        {
            cache.Add(key, value, expiredTime);
        }

        //Get values from cache
        public static T GetFromCache<T>(string key)
        {
            return (T)cache[key];
        }
    }
}