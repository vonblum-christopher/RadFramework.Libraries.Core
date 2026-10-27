using ConsoleApp1;

namespace RadFramework.Libraries.Core_Tests;

public class PipeC : PipeBase<ulong, byte[]>
{
    public override byte[] Process(ulong input)
    {
        return BitConverter.GetBytes(input);
    }
}