using RadFramework.Libraries.Core.Ioc.Base;

namespace RadFramework.Libraries.Core.Ioc;

public class IocDependencyAttribute : Attribute
{
    public NamedIocKey Key { get; set; } = new();
    
    public IocDependencyAttribute()
    {
    }
    
    public IocDependencyAttribute(string key)
    {
        Key.KeyName = key;
    }
    
    public IocDependencyAttribute(Type keyType, string key)
    {
        Key.KeyName = key;
        Key.KeyType = keyType;
    }
}