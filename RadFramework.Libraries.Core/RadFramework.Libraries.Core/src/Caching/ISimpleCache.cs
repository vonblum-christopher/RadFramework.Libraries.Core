namespace RadFramework.Libraries.Core.Caching;

public interface ISimpleCache
{
    TObject Get<TObject>(string key);
    TObject GetOrSet<TObject>(string key, Func<TObject> factory, CachingOptions cachingOptions = null);
    void Set<TObject>(string key, TObject o, CachingOptions cachingOptions = null);
    ISimpleCache CreateChildCache();
}