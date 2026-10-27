using System.Collections.Immutable;
using RadFramework.Libraries.Core.Ioc.Base;
using RadFramework.Libraries.Core.Ioc.Builder;

namespace RadFramework.Libraries.Core.Ioc;

public interface IIocContainer
{
    List<IIocContainer> ParentContainers { get; set; }
    ImmutableList<IocDependency> ServiceList { get; }
    IImmutableDictionary<IIocKey, IocDependency> ServiceLookup { get; }
        
    bool HasService(IIocKey key);
        
    object Resolve(IIocKey key);

    object Activate(TypeIocKey key);
}