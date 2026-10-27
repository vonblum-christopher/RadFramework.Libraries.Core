using RadFramework.Libraries.Core.Ioc.Builder;
using RadFramework.Libraries.Core.Ioc.InjectionLambdaFactory;
using RadFramework.Libraries.Core.Ioc.IocContainers;

namespace RadFramework.Libraries.Core.Ioc.InstanceContainers;

public class TransientFactoryInstanceContainer : InstanceContainerBase
{
    private Func<IocDependency, IIocContainer, object> factoryFunc;
        
    public override void Initialize(IocDependency dependency)
    {
        factoryFunc = dependency.FactoryFunc
                      ?? ServiceFactoryLambdaGenerator.DefaultInstance.CreateTypeFactoryLambda(dependency);
    }

    public override object ResolveService(IocContainerKeyedWithType containerKeyed, IocDependency dependency)
    {
        return factoryFunc(dependency, containerKeyed);
    }

    public override InstanceContainerBase Clone()
    {
        return new TransientInstanceContainer()
        {
            IocDependency = IocDependency.Clone(),
        };
    }
}