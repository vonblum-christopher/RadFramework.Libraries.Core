using System.Collections.Concurrent;
using RadFramework.Libraries.Core.Ioc.Base;
using RadFramework.Libraries.Core.Ioc.Builder;

namespace RadFramework.Libraries.Core.Ioc.InstanceContainers;

public class InstanceContainerRegistry
{
    private IocBuilderRegistry builderRegistry;

    private ConcurrentDictionary<NamedIocKey, InstanceContainerBase> Containers;
    public InstanceContainerRegistry(IocBuilderRegistry builderRegistry)
    {
        this.builderRegistry = builderRegistry.Clone();
    }
}