namespace RadFramework.Libraries.Core.Model.Attributes;

public class IdentifierAttribute(string identityGroup, string propertyKey = null) : Attribute
{
    public string IdentityGroup { get; } = identityGroup;
    public string PropertyKey { get; } = propertyKey;
}