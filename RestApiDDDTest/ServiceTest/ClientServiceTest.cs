using System;
using Xunit;
using Moq;
using RestApiDDD.Application;
using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Application.Mapper;
using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Core.Interfaces.Services;
using RestApiDDD.Domain.Services;

namespace RestApiDDDTest.ServiceTest;

public class ClientServiceTest
{
    private readonly IClientService _clientService;
    private readonly IClientMapper _clientMapper;
    private readonly ClientServiceApplication _clientServiceApplication;
    public ClientServiceTest()
    {
        _clientService = new ClientService(
            new Mock<IClientRepository>().Object);
        _clientMapper = new Mock<IClientMapper>().Object;
        _clientServiceApplication = new ClientServiceApplication(
            _clientService,
            _clientMapper);
    }
    [Fact(DisplayName="Service Constructor Must Not Throw Exception")]
    public void ClientServiceApplicationConstructorTest()
    {
        Assert.IsType<ClientServiceApplication>(_clientServiceApplication);
    }

    [Fact]
    public async void CreateClientServiceSuccessTest()
    {
        ClientDTO requestDTO = new ClientDTO
        {
            Name = "Fernando",
            LastName = "Andrade",
            Email = "nando@gmail.com",
            
        };
        var result = await _clientServiceApplication.Add(requestDTO);
        Assert.Equal("Cliente cadastrado com sucesso.", result.Message);
    }
    
   [ Fact]
    public async void CreateClientServiceFailTest()
    {
        ClientDTO requestDTO = new ClientDTO
        {
            LastName = "Andrade",
            Email = "nando@gmail.com",
            
        };
        var result = await _clientServiceApplication.Add(requestDTO);
        Assert.Equal("Error ao cadastrar o cliente, nome do cliente não enviado.", result.Message);
    }
    
  
}