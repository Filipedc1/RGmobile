using System;
using System.Collections.Generic;
using System.Text;

namespace RGmobile.API_Services
{
    // Add Akavache library which uses sqlite3
    public class BaseService
    {
        //protected IBlobCache Cache;

        //public BaseService(IBlobCache cache)
        //{
        //    Cache = cache ?? BlobCache.LocalMachine;
        //}

        //public async Task<T> GetFromCache<T>(string cacheName)
        //{
        //    try
        //    {
        //        T t = await Cache.GetObject<T>(cacheName);
        //        return t;
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return default(T);
        //    }
        //}

        //public void InvalidateCache()
        //{
        //    Cache.InvalidateAllObjects<Pie>();
        //}
    }
}
