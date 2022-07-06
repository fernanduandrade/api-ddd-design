using Autofac;
using RestApiDDD.Application;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Application.Interfaces.Mapper;
using RestApiDDD.Application.Mapper;
using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Core.Interfaces.Services;
using RestApiDDD.Domain.Services;
using RestApiDDD.Infra.Data.Repositories;
namespace RestApiDDD.Infra.CrossCutting.IOC;

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