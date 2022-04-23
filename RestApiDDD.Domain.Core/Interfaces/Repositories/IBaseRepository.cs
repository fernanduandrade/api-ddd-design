namespace RestApiDDD.Domain.Core.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    // T é uma entidade anonima 
    Task<T> Add(T obj);
    void Update(T obj);
    void Remove(T obj);
    IEnumerable<T> GetAll();
    T GetById(int id);

}