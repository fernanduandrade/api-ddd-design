using Microsoft.EntityFrameworkCore;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Infra.Data;

public class LocalContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public LocalContext(DbContextOptions<LocalContext> options) : base(options) {}

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