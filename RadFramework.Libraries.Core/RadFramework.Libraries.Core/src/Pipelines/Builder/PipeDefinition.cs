using RadFramework.Libraries.Core.Abstractions;
using RadFramework.Libraries.Core.Reflection.Caching;

namespace RadFramework.Libraries.Core.Pipelines.Builder;

public class PipeDefinition : ICloneable<PipeDefinition>
{
    public string Key { get; private set; }
        
    public CachedType Type { get; }

    public PipeDefinition(CachedType type) : this(type, null)
    {
    }

    public PipeDefinition(CachedType type, string key = null)
    {
        Type = type;
        Key = key;
    }

    public PipeDefinition Clone()
    {
        return new PipeDefinition(Type, Key);
    }
}