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
    public void Add(T obj)
    {
        _baseRepository.Add(obj);
    }

    public void Update(T obj)
    {
        _baseRepository.Update(obj);
    }

    public void Remove(T obj)
    {
        _baseRepository.Remove(obj);
    }

    public IEnumerable<T> GetAll()
    {
        return _baseRepository.GetAll();
    }

    public T GetById(int id)
    {
        return _baseRepository.GetById(id);
    }
}