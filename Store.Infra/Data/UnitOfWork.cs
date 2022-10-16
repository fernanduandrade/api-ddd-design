using Microsoft.EntityFrameworkCore;

namespace Store.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async void CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void RollBack()
        {
            // Ao chamar o Rollback não realizada nada, pois não irá persistir no banco
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
