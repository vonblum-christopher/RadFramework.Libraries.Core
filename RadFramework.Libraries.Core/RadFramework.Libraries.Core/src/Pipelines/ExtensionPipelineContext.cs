namespace RadFramework.Libraries.Core.Pipelines;

public class ExtensionPipelineContext<TOutput> : ExtensionPipelineContextBase
{
    public TOutput ReturnValue { get; set; }

    public void Return(TOutput returnValue)
    {
        ShouldReturn = true;
        ReturnValue = returnValue;
    }
}