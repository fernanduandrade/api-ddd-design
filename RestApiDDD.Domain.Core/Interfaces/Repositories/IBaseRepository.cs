using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Domain.Core.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    // T é uma entidade anonima 
    Task<T> Add(T obj);
    Task<T> Update(T obj);
    Task<T> Remove(T obj);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
}