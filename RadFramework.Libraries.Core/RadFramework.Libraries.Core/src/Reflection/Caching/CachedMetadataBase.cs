using System.Collections.Concurrent;

namespace RadFramework.Libraries.Core.Reflection.Caching;

public class CachedMetadataBase<TMetadata>
{
    public TMetadata InnerMetaData { get; internal set; }
    
    private ConcurrentDictionary<string, object> queryCache = new();

    public TResult Query<TResult>(Func<TMetadata, TResult> query)
    {
        return (TResult) queryCache.GetOrAdd(query.Method.DeclaringType.AssemblyQualifiedName + query.Method.MetadataToken.ToString(), (i) => query(InnerMetaData));
    }
}