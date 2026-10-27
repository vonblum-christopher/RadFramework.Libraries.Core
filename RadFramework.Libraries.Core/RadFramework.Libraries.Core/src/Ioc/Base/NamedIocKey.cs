namespace RadFramework.Libraries.Core.Ioc.Base;

public class NamedIocKey : IIocKey
{
    public string KeyName { get; set; }
    
    public SortedDictionary<string, object> KeyProperties =>
        new()
        {
            { nameof(KeyName), KeyName }
        };

    public IIocKey Clone()
    {
        return new NamedIocKey
        {
            KeyName = KeyName
        };
    }

}