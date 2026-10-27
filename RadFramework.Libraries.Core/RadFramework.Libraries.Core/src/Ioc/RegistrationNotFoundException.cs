namespace RadFramework.Libraries.Core.Ioc;

public class RegistrationNotFoundException : Exception
{
    public Type T { get; }

    public RegistrationNotFoundException(Type t)
    {
        T = t;
    }
}