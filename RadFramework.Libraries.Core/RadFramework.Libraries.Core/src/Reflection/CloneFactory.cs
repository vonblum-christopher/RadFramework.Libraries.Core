using System.Reflection;
using System.Runtime.Serialization;
using RadFramework.Libraries.Core.Reflection.Caching;

namespace RadFramework.Libraries.Core.Reflection;

public class CloneFactory
{
    public static object DeepClone(object toClone)
    {
        object clone = FormatterServices.GetUninitializedObject(toClone.GetType());

        foreach (FieldInfo fieldInfo in ((CachedType)toClone.GetType()).Query(t => t.GetFields(BindingFlags.Instance)))
        {
            if (fieldInfo.FieldType.IsPrimitive || fieldInfo.FieldType == typeof(string))
            {
                fieldInfo.SetValue(clone, fieldInfo.GetValue(toClone));
                continue;
            }
            
            fieldInfo.SetValue(clone, DeepClone(fieldInfo.GetValue(toClone)));
        }
            
        return clone;
    }
    
    public static object FlatClone(object toClone, bool populateReferences = false)
    {
        object clone = FormatterServices.GetUninitializedObject(toClone.GetType());

        foreach (FieldInfo fieldInfo in ((CachedType)toClone.GetType()).Query(t => t.GetFields(BindingFlags.Instance)))
        {
            if (fieldInfo.FieldType.IsPrimitive || fieldInfo.FieldType == typeof(string))
            {
                fieldInfo.SetValue(clone, fieldInfo.GetValue(toClone));
            }
        }
        
        return clone;
    }
}