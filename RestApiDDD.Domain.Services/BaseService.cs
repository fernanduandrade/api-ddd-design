using RestApiDDD.Domain.Core.Interfaces.Repositories;
using RestApiDDD.Domain.Core.Interfaces.Services;

namespace RestApiDDD.Domain.Services;

public class BaseService<T> : IBaseService<T> where T : class
{
    private readonly IBaseRepository<T> _baseRepository;

    public BaseService(IBaseRepository<T> baseRepository)
    {
        _baseRepository = baseRepository;
    }
    public async Task Add(T obj)
    {
        await _baseRepository.Add(obj);
    }

    public async Task Update(T obj)
    {
        await _baseRepository.Update(obj);
    }

    public async Task Remove(T obj)
    {
        await _baseRepository.Remove(obj);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _baseRepository.GetAll();
    }

    public async Task<T?> GetById(int id)
    {
        return await _baseRepository.GetById(id);
    }
}