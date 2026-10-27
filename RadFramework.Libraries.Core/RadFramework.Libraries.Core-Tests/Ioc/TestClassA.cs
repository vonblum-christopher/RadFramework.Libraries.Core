namespace RadFramework.Libraries.Core_Tests.Ioc;

public class TestClassA
{
    
    public TestClassA(TestClassB b)
    {
        B = b;
    }

    public TestClassB B
    {
        get;
        set;
    }
    
    []
    public TestClassB C
    {
        get;
        set;
    }
    
    public TestClassD D
    {
        get;
        set;
    }

    public void InjectHere(TestClassD d)
    {
        D = d;
    }
}

public class TestClassB
{
    public TestClassB(TestClassC c)
    {
        C = c;
    }
    
    private TestClassC C { get; set; }
}

public class TestClassC
{
}

public class TestClassD
{
    
}