using System.Collections.Concurrent;

namespace RadFramework.Libraries.Core.Caching;

public class SimpleCache : ISimpleCache
{
    private readonly SimpleCache _parentCache;
    private ConcurrentDictionary<string, object> cache = new();
        
    public SimpleCache()
    {
    }
        
    public SimpleCache(SimpleCache parentCache)
    {
        _parentCache = parentCache;
    }
        
    public TObject Get<TObject>(string key)
    {
        if (cache.ContainsKey(key))
        {
            return (TObject)cache[key];
        }
            
        if (_parentCache != null && _parentCache.cache.ContainsKey(key))
        {
            return _parentCache.Get<TObject>(key);
        }

        throw new KeyNotFoundException();
    }

    public TObject GetOrSet<TObject>(string key, Func<TObject> factory, CachingOptions cachingOptions = null)
    {
        TObject result = default;

        try
        {
            result = Get<TObject>(key);
        }
        catch (KeyNotFoundException)
        {
            result = factory();
            Set(key, result);
        }

        return result;
    }

    public void Set<TObject>(string key, TObject o, CachingOptions cachingOptions = null)
    {
        cache[key] = o;
    }

    public ISimpleCache CreateChildCache()
    {
        return new SimpleCache(this);
    }
}