using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Core.Interfaces.Services;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Domain.Services;

public class ClientService : BaseService<Client>, IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository) : base(clientRepository)
    {
        _clientRepository = clientRepository;
    }
}