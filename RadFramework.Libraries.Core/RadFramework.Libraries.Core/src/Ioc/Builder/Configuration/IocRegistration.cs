namespace RadFramework.Libraries.Core.Ioc.Builder.Configuration;

public interface IocRegistration
{
    string TKey { get; set; }
    string TImplementation { get; set; }
    string Lifecycle { get; set; }
}