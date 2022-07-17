using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Interfaces.Repositories;

namespace Store.Infra.Data.Repositories;

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

    public async Task<T> Update(T obj)
    {
        try
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return  obj;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<T> Remove(T obj)
    {
        try
        {
            _context.Set<T>().Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
}