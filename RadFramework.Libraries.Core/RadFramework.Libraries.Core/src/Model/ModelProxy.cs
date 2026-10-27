using System.Collections.Immutable;
using System.Reflection;
using RadFramework.Libraries.Core.Model.Attributes;
using RadFramework.Libraries.Core.Reflection.Caching;

namespace RadFramework.Libraries.Core.Model;

public class ModelProxy : DispatchProxy
{
    public IModel GetIdentityModel(string identityGroup)
    {
        IModel model = ModelFactory.CreateModelObject<IModel>();
            
        model.Properties = 
            ((CachedType)this
            .GetType())
            .Query(t =>
                t
                    .GetInterfaces()
                    .SelectMany(i => i.GetProperties())
                    .Where(p => 
                        p
                            .GetCustomAttributes(true)
                            .Any(a => a is IdentifierAttribute attr && attr.IdentityGroup == identityGroup)
                    )
                    .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(this)))
                    .ToImmutableSortedDictionary());

        return model;
    }
    public IModel GetPropertyGroup(string propertyGroup)
    {
        IModel model = ModelFactory.CreateModelObject<IModel>();
            
        model.Properties = 
            ((CachedType)this
                .GetType())
            .Query(t =>
                t
                    .GetInterfaces()
                    .SelectMany(i => i.GetProperties())
                    .Where(p => 
                        p
                            .GetCustomAttributes(true)
                            .Any(a => a is PropertyAttribute attr && attr.PropertyGroup == propertyGroup)
                    )
                    .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(this)))
                    .ToImmutableSortedDictionary());

        return model;
    }
    
    public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    
    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        if (targetMethod.Name == nameof(GetIdentityModel))
        {
            return GetIdentityModel((string)args[0]);
        }
        
        if (targetMethod.Name == nameof(GetPropertyGroup))
        {
            return GetPropertyGroup((string)args[0]);
        }
        
        if (targetMethod.Name == $"get_{nameof(Properties)}")
        {
            return Properties;
        }
        
        if (targetMethod.Name == $"set_{nameof(Properties)}")
        {
            Properties = (IDictionary<string, object>)args[0];
            return null;
        }
            
        if (!(targetMethod.Name.StartsWith("get_") || targetMethod.Name.StartsWith("set")) || !targetMethod.IsSpecialName)
        {
            return targetMethod.Invoke(this, args);
        }
        
        string propertyName = targetMethod.Name.Substring(4);
        
        if (targetMethod.Name.StartsWith("get_"))
        {
            if (!Properties.ContainsKey(propertyName))
            {
                return null;
            }

            return Properties[propertyName];
        }
        else if (targetMethod.Name.StartsWith("set_"))
        {
            Properties[propertyName] = args[0];
            return null;
        }

        return null;
    }
}