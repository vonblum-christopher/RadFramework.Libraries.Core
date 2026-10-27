using ConsoleApp1;

namespace RadFramework.Libraries.Core_Tests;

public class PipeB : PipeBase<string, ulong>
{
    public override ulong Process(string input)
    {
        return ulong.Parse(input);
    }
}