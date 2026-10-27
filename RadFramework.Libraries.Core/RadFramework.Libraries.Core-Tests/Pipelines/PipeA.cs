using ConsoleApp1;

namespace RadFramework.Libraries.Core_Tests;

public class PipeA : PipeBase<int, string>
{
    public override string Process(int input)
    {
        return input.ToString();
    }
}