namespace RestApiDDD.Domain.Core.Interfaces.Services;

public interface IBaseService<T> where T : class
{
    Task Add(T obj);
    Task Update(T obj);
    Task Remove(T obj);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
}