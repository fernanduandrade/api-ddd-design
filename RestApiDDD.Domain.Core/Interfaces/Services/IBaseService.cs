namespace RestApiDDD.Domain.Core.Interfaces.Services;

public interface IBaseService<T> where T : class
{
    void Add(T obj);
    void Update(T obj);
    void Remove(T obj);
    IEnumerable<T> GetAll();
    T GetById(int id);
}