using Autofac;

namespace RestApiDDD.Infra.CrossCutting.IOC;

public class IocModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        IocConfiguration.Load(builder);
    }
}