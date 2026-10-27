using System.Reflection;

namespace RadFramework.Libraries.Core.Reflection.Caching;

public class CachedEventInfo : CachedMetadataBase<EventInfo>
{
    public static implicit operator EventInfo(CachedEventInfo cachedEventInfo)
        => cachedEventInfo.InnerMetaData;
    public static implicit operator CachedEventInfo(EventInfo eventInfo)
        => ReflectionCache.CurrentCache.GetCachedMetaData(eventInfo);
}