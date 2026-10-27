using RadFramework.Libraries.Core.Ioc.Builder;
using RadFramework.Libraries.Core.Ioc.InjectionLambdaFactory;
using RadFramework.Libraries.Core.Ioc.IocContainers;

namespace RadFramework.Libraries.Core.Ioc.InstanceContainers;

public class SingletonInstanceContainer : InstanceContainerBase
{
    private DataTypes.Lazy<object> singleton;

    private Func<IocDependency, IIocContainer, object> factoryFunc;

    private IocDependency dependency;
        
    public override void Initialize(IocDependency dependency)
    {
        dependency = this.dependency;
        factoryFunc = dependency.FactoryFunc ?? ServiceFactoryLambdaGenerator.DefaultInstance.CreateTypeFactoryLambda(dependency);
    }

    public override object ResolveService(IocContainerKeyedWithType containerKeyed, IocDependency dependency)
    {
        if (singleton == null)
        {
            singleton = new DataTypes.Lazy<object>(() => factoryFunc(dependency, containerKeyed));
        }
            
        return singleton.Value;
    }

    public override InstanceContainerBase Clone()
    {
        return new SingletonInstanceContainer()
        {
            IocDependency = dependency.Clone()
        };
    }
}