using System.Collections.Concurrent;
using RadFramework.Libraries.Core.Abstractions;
using RadFramework.Libraries.Core.Ioc.Builder;
using RadFramework.Libraries.Core.Ioc.IocContainers;

namespace RadFramework.Libraries.Core.Ioc.InjectionLambdaFactory;

public class InjectionLambdaManager<TIocKey> where TIocKey : ICloneable<TIocKey>
{
    private static ConcurrentDictionary<TIocKey, Func<IocContainerKeyedWithType, object>> factoryCache = new();
    
    public static Func<IocContainerKeyedWithType, object> GetOrCreateConstructionFunc(TIocKey key, IocDependency registration)
    {
        return factoryCache.GetOrAdd(
            key,
            tuple => ServiceFactoryLambdaGenerator.DefaultInstance.CreateTypeFactoryLambda(registration));
    }
}