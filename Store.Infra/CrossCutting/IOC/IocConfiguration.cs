using Autofac;
using Store.Application;
using Store.Application.Interfaces;
using Store.Application.Interfaces.Mapper;
using Store.Application.Mapper;
using Store.Domain.Core.Interfaces.Repositories;
using Store.Domain.Core.Interfaces.Services;
using Store.Domain.Services;
using Store.Infra.Data.Repositories;
namespace Store.Infra.CrossCutting.IOC;

public class IocConfiguration
{
    public static void Load(ContainerBuilder builder)
    {
        // Aplicação
        builder.RegisterType<ClientServiceApplication>().As<IClientServiceApplication>();
        builder.RegisterType<ProductServiceApplication>().As<IProductServiceApplication>();
        builder.RegisterType<UserServiceApplication>().As<IUserServiceApplication>();

        // Serviços
        builder.RegisterType<ClientService>().As<IClientService>();
        builder.RegisterType<ProductService>().As<IProductService>();
        builder.RegisterType<UserService>().As<IUserService>();

        // Repositórios
        builder.RegisterType<ClientRepository>().As<IClientRepository>();
        builder.RegisterType<ProductRepository>().As<IProductRepository>();
        builder.RegisterType<UserRepository>().As<IUserRepository>();

        // Mapeadores
        builder.RegisterType<ClientMapper>().As<IClientMapper>();
        builder.RegisterType<ProductMapper>().As<IProductMapper>();
        builder.RegisterType<UserMapper>().As<IUserMapper>();
    }
}