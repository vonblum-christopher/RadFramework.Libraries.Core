using RadFramework.Libraries.Core.Abstractions;

namespace RadFramework.Libraries.Core.Pipelines.Builder;

public class PipeRegistry : ICloneable<PipeRegistry>
{
    public List<PipeDefinition> PipeDefinitions = new();

    public PipeRegistry Clone()
    {
        return new PipeRegistry
        {
            PipeDefinitions = PipeDefinitions.Select(d => d.Clone()).ToList()
        };
    }
}