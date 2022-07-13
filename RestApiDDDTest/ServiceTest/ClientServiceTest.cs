using Xunit;
using Moq;
using RestApiDDD.Application;
using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces.Mapper;
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

    [Fact(DisplayName="Service should create a client successively")]
    public async void CreateClientServiceSuccessTest()
    {
        ClientDTO requestDTO = new ClientDTO
        {
            Name = "Fernando",
            LastName = "Andrade",
            
        };
        var result = await _clientServiceApplication.Add(requestDTO);
        Assert.Equal("Cliente cadastrado com sucesso.", result.Message);
    }
    
    [Fact(DisplayName="Test should fail if name is null or empty")]
    public async void CreateClientServiceFailTest()
    {
        ClientDTO requestDTO = new ClientDTO
        {
            LastName = "Andrade",
        };
        var result = await _clientServiceApplication.Add(requestDTO);
        Assert.Equal("Error ao cadastrar o cliente, nome do cliente não enviado.", result.Message);
    }

    [Theory(DisplayName="Delete client should return true if id is greater than 0 and false if equal a 0 or null")]
    [InlineData(0, false)]
    [InlineData(null, false)]
    [InlineData(6, true)]
    public async void DeleteClientServiceSuccessTest(int id, bool expected)
    {
        ClientDTO requestDTO = new ClientDTO
        {
            Id = id,
            Name = "Fernando",
            LastName = "Andrade",
        };

        var result = await _clientServiceApplication.Remove(requestDTO);
        Assert.Equal(expected, result.DataResult);
    }
}