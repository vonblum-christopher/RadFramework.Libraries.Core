using System.Collections.Immutable;
using RadFramework.Libraries.Core.Ioc.Base;
using RadFramework.Libraries.Core.Ioc.Builder;

namespace RadFramework.Libraries.Core.Ioc.IocContainers;

public class IocContainerKeyedWithTypeAndName : IocContainerKeyedWithType, IDependencyNameAwareIocContainer
{
    public ImmutableList<IocDependency> ServiceList { get; }
    public IImmutableDictionary<IIocKey, IocDependency> ServiceLookup { get; }
    public bool HasService(IIocKey key)
    {
        return ServiceLookup.ContainsKey(key);
    }

    public object Resolve(IIocKey key)
    {
        throw new NotImplementedException();
    }

    public object Activate(IIocKey key)
    {
        throw new NotImplementedException();
    }
}