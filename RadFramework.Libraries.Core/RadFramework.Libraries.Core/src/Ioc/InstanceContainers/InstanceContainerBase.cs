using RadFramework.Libraries.Core.Abstractions;
using RadFramework.Libraries.Core.Ioc.Builder;
using RadFramework.Libraries.Core.Ioc.IocContainers;

namespace RadFramework.Libraries.Core.Ioc.InstanceContainers;

public abstract class InstanceContainerBase : ICloneable<InstanceContainerBase>
{
    public IocDependency IocDependency { get; set; }

    public virtual void Initialize(IocDependency dependency)
    {
        IocDependency = dependency;
    }
        
    public abstract object ResolveService(IocContainerKeyedWithType containerKeyed, IocDependency dependency);
        
    public abstract InstanceContainerBase Clone();
}