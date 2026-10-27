using RadFramework.Libraries.Core.Reflection.Caching;

namespace RadFramework.Libraries.Core.Ioc.Base;

public class TypeIocKey : IIocKey
{
    public CachedType KeyType { get; set; }
    
    public SortedDictionary<string, object> KeyProperties =>
        new()
        {
            { nameof(KeyType), KeyType }
        }; 
    
    public IIocKey Clone() =>
        new TypeIocKey()
            {
                KeyType = KeyType
            };
}