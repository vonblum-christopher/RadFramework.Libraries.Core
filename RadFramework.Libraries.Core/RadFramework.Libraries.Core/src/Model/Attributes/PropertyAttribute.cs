namespace RadFramework.Libraries.Core.Model.Attributes;

public class PropertyAttribute(string propertyGroup, string propertyKey = null) : Attribute
{
    public string PropertyGroup { get; } = propertyGroup;
    public string PropertyKey { get; } = propertyKey;
}