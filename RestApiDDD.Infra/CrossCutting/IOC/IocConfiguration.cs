using Autofac;
using RestApiDDD.Application;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Application.Interfaces.Mapper;
using RestApiDDD.Application.Mapper;
using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Core.Interfaces.Services;
using RestApiDDD.Domain.Services;
using RestApiDDD.Infra.Data.Repositories;
using IClientMapper = RestApiDDD.Application.Interfaces.IClientMapper;

namespace RestApiDDD.Infra.CrossCutting.IOC;

public class IocConfiguration
{
    public static void Load(ContainerBuilder builder)
    {
        // Aplicação
        builder.RegisterType<ClientServiceApplication>().As<IClientServiceApplication>();
        builder.RegisterType<ProductServiceApplication>().As<IProductServiceApplication>();
        
        // Serviços
        builder.RegisterType<ClientService>().As<IClientService>();
        builder.RegisterType<ProductService>().As<IProductService>();
        
        // Repositórios
        builder.RegisterType<ClientRepository>().As<IClientRepository>();
        builder.RegisterType<ProductRepository>().As<IProductRepository>();
        
        // Mapeadores
        builder.RegisterType<ClientMapper>().As<IClientMapper>();
        builder.RegisterType<ProductMapper>().As<IProductMapper>();
    }
}