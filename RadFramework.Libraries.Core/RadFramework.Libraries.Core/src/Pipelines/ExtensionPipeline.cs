using RadFramework.Libraries.Core.Pipelines.Base;
using RadFramework.Libraries.Core.Pipelines.Builder;

namespace RadFramework.Libraries.Core.Pipelines;

public class ExtensionPipeline<TInput, TOutput> : ExtensionPipelineBase
{
    public ExtensionPipeline(PipelineBuilder builder, ITypeOnlyIocContainer container) : base(builder.Clone().PipeDefinitions, container)
    {
    }
    
    public TOutput Process(TInput input)
    {
        return Process(input, new ExtensionPipelineContext<TOutput>()).ReturnValue;
    }
    
    public ExtensionPipelineContext<TOutput> Process(TInput input, ExtensionPipelineContext<TOutput> pipelineContext)
    {
        foreach (IExtensionPipe pipe in pipes)
        {
            try
            {
                pipe.Process(input, pipelineContext);
            }
            catch (Exception e)
            {
                pipelineContext.Error(e);
            }
            
            if (pipelineContext.ShouldReturn)
            {
                return pipelineContext;
            }
        }

        return pipelineContext;
    }
}