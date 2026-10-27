using System.Reflection;

namespace RadFramework.Libraries.Core.Model;

public class ModelFactory
{
    public static TModel CreateModelObject<TModel>()
        where TModel : IModel
    {
        return (TModel)DispatchProxy.Create(typeof(TModel), typeof(ModelProxy));
    }
    
}