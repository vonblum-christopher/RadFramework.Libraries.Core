using RadFramework.Libraries.Core.Abstractions;

namespace RadFramework.Libraries.Core.Ioc.Base;

public interface IIocKey : ICloneable<IIocKey>
{
    SortedDictionary<string, object> KeyProperties { get; }
}