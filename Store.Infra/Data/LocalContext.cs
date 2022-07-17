using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infra.Data.Mapping;

namespace Store.Infra.Data;

public class LocalContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public LocalContext(DbContextOptions<LocalContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>(new ClientsMap().Configure);
        modelBuilder.Entity<Product>(new ProductsMap().Configure);
        modelBuilder.Entity<User>(new UsersMap().Configure);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker
                     .Entries()
                     .Where(
                         entry => entry.Entity.GetType().GetProperty("CreatedOn") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedOn").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreatedOn").IsModified = false;
            }
        }

        return base.SaveChanges();
    }
}