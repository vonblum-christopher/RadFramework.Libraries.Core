using System.Collections.Immutable;
using RadFramework.Libraries.Core.Ioc.Builder;
using RadFramework.Libraries.Core.Ioc.InstanceContainers;
using RadFramework.Libraries.Core.Ioc.IocContainers;
using RadFramework.Libraries.Core.Reflection.Caching;

namespace RadFramework.Libraries.Core.Ioc.Base;

public class IocContainerBase : IIocContainer, IServiceProvider
{
    private readonly InjectionOptions injectionOptions;
    public List<IIocContainer> ParentContainers { get; set; } = new List<IIocContainer>();
    public ImmutableList<IocDependency> ServiceList => ServiceLookup.Values.ToImmutableList();
    public IImmutableDictionary<IIocKey, IocDependency> ServiceLookup { get; }

    public IocContainerBase(IocContainerBuilder builder, InjectionOptions injectionOptions)
    {
        this.injectionOptions = injectionOptions;
        ServiceLookup = builder.IocBuilderRegistry.Clone().Registrations.ToImmutableDictionary();
    }
    
    public virtual bool HasService(IIocKey key)
    {
        IIocContainer container = GetContainer(key);

        if (container == null)
        {
            return false;
        }
        
        return true;
    }

    public object Resolve(IIocKey key)
    {
        IIocContainer container = GetContainerOrThrow(key);

        return container.Resolve(key);
    }

    public object Activate(TypeIocKey key)
    {
        return Activate(key);
    }

    public object Activate(IIocKey key)
    {
        IocDependency iocDependency = new()
        {
            ImplementationType = (CachedType)key.KeyProperties[nameof(TypeIocKey.KeyType)],
            InjectionOptions = injectionOptions.Clone(),
            Key = key,
            IocLifecycle = IocLifecycles.Transient
        };

        TransientInstanceContainer instanceContainer = new()
        {
            IocDependency = iocDependency,
        };
        
        instanceContainer.Initialize(iocDependency);
        
        return instanceContainer.ResolveService(this, iocDependency);
    }
    
    public object GetService(Type serviceType)
    {
        TypeIocKey key = new TypeIocKey() { KeyType = serviceType };

        IIocContainer container = GetContainerOrThrow(key);
        
        return container.Resolve(key);
    }

    public IIocContainer GetContainerOrThrow(IIocKey key)
    {
        IIocContainer container = GetContainer(key);

        if (container == null)
        {
            throw new Exception("Service not found");
        }

        return container;
    }

    public IIocContainer GetContainer(IIocKey key)
    {
        if (ServiceLookup.ContainsKey(key))
        {
            return this;
        }
        
        for(int i = ParentContainers.Count; i != 0; i--)
        {
            if (ParentContainers[i].ServiceLookup.ContainsKey(key))
            {
                return ParentContainers[i];
            }
        }

        return null;
    }
    
    public IocContainerKeyedWithType Clone()
    {
        throw new NotImplementedException();
    }
}