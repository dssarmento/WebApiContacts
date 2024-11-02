using System.Runtime.Caching;

namespace Contacts.Data.Utils
{
    public static class CacheManager
    {
        private static MemoryCache _cache = MemoryCache.Default;
        private static readonly object _lockObject = new object();

        public static T ObterOuDefinirCache<T>(string chaveValor, Func<T> getItemCallback, DateTimeOffset dataDeExpiracao)
        {
            if (!_cache.Contains(chaveValor))
            {
                lock (_lockObject)
                {
                    if (!_cache.Contains(chaveValor))
                    {
                        T item = getItemCallback();
                        _cache.Set(chaveValor, item, dataDeExpiracao);
                    }
                }
            }
            return (T)_cache.Get(chaveValor);
        }
        public static void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
