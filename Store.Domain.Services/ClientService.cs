using Store.Domain.Core.Interfaces.Repositories;
using Store.Domain.Core.Interfaces.Services;
using Store.Domain.Entities;

namespace Store.Domain.Services;

public class ClientService : BaseService<Client>, IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository) : base(clientRepository)
    {
        _clientRepository = clientRepository;
    }
}