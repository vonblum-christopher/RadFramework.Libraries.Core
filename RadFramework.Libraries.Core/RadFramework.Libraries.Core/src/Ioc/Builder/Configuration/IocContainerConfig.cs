namespace RadFramework.Libraries.Core.Ioc.Builder.Configuration;

public interface IocContainerConfig
{
    IEnumerable<IocRegistration> Registrations { get; set; }
}