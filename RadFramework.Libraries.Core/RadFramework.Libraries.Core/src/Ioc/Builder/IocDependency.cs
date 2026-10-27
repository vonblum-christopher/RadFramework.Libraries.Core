using RadFramework.Libraries.Core.Abstractions;
using RadFramework.Libraries.Core.Ioc.Base;
using RadFramework.Libraries.Core.Reflection.Caching;

namespace RadFramework.Libraries.Core.Ioc.Builder;

public class IocDependency : ICloneable<IocDependency>
{
    public IIocKey Key { get; set; }
    public CachedType ImplementationType { get; set; }
    public InjectionOptions InjectionOptions { get; set; }
    public string IocLifecycle { get; set; }
    public Func<IocDependency, IIocContainer, object> FactoryFunc { get; set; }
    
    public IocDependency Clone()
    {
        return new IocDependency
        {
            Key = Key.Clone(),
            ImplementationType = ImplementationType,
            InjectionOptions = InjectionOptions.Clone(),
            IocLifecycle = IocLifecycle
        };
    }
}