namespace RadFramework.Libraries.Core.Pipelines.Base;

public abstract class ExtensionPipeBase<TInput, TOutput> : IExtensionPipe<TInput, TOutput>, IExtensionPipe
{
    public abstract void Process(TInput input, ExtensionPipelineContext<TOutput> pipelineContext);

    public void Process(object input, ExtensionPipelineContextBase pipelineContext)
    {
        Process((TInput)input, (ExtensionPipelineContext<TOutput>)pipelineContext);
    }
}