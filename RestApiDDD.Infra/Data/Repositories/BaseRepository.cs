using Microsoft.EntityFrameworkCore;
using RestApiDDD.Domain.Core.Interfaces.Repositories;

namespace RestApiDDD.Infra.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly LocalContext _context;

    public BaseRepository(LocalContext context)
    {
        _context = context;
    }
    public async Task<T> Add(T obj)
    {
        try
        {   _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Update(T obj)
    {
        try
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Remove(T obj)
    {
        try
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
}