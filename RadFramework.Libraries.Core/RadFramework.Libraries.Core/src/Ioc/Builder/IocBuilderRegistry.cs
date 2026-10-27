using System.Collections.Concurrent;
using RadFramework.Libraries.Core.Abstractions;
using RadFramework.Libraries.Core.Ioc.Base;

namespace RadFramework.Libraries.Core.Ioc.Builder;

public class IocBuilderRegistry : ICloneable<IocBuilderRegistry>
{
    public ConcurrentDictionary<IIocKey, IocDependency> Registrations = new();

    public IocBuilderRegistry Clone()
    {
        return new IocBuilderRegistry()
        {
            Registrations = new ConcurrentDictionary<IIocKey, IocDependency>
            (Registrations
                .ToDictionary(
                    k => k.Key.Clone(),
                    v => v.Value.Clone()))
        };
    }

    public IocDependency this[IIocKey namedIocKey]
    {
        get => Registrations[namedIocKey];
        set => Registrations[namedIocKey] = value;
    }
}