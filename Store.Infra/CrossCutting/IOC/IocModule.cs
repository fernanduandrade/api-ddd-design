using Autofac;

namespace Store.Infra.CrossCutting.IOC;

public class IocModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        IocConfiguration.Load(builder);
    }
}