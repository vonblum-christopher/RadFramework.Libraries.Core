using RadFramework.Libraries.Core.Ioc.Builder;
using RadFramework.Libraries.Core.Ioc.InjectionLambdaFactory;
using RadFramework.Libraries.Core.Ioc.IocContainers;

namespace RadFramework.Libraries.Core.Ioc.InstanceContainers;

public class TransientInstanceContainer : InstanceContainerBase
{
    private DataTypes.Lazy<Func<IocDependency, IIocContainer, object>> construct;
    
    public override void Initialize(IocDependency dependency)
    {
        this.construct = new DataTypes.Lazy<Func<IocDependency, IIocContainer, object>>(
            () => 
                dependency.FactoryFunc 
                ?? ServiceFactoryLambdaGenerator.DefaultInstance.CreateTypeFactoryLambda(dependency));
    }

    public override object ResolveService(IocContainerKeyedWithType containerKeyed, IocDependency dependency)
    {
        return construct.Value(dependency, containerKeyed);
    }

    public override InstanceContainerBase Clone()
    {
        return new TransientInstanceContainer()
        {
            IocDependency = IocDependency.Clone()
        };
    }
}