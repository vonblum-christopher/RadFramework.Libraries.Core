namespace RadFramework.Libraries.Core.Model;

public interface IModel
{
    IModel GetIdentityModel(string identityGroup);
    IModel GetPropertyGroup(string identityGroup);
    
    IDictionary<string, object> Properties { get; set; }
}