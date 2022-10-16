namespace Store.Infra.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void RollBack();
        void CommitAsync();
    }
}
