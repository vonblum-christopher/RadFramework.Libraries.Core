using System.IO.Pipelines;
using ConsoleApp1;

namespace RadFramework.Libraries.Core_Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PipelineBuilderAppendCompileTimeCheck()
    {
        PipelineBuilder<int> builder = new PipelineBuilder<int>();

        builder
            .Append(new PipeA())
            .Append(new PipeB())
            .Append(new PipeC());
        
        Assert.Pass();
    }
}