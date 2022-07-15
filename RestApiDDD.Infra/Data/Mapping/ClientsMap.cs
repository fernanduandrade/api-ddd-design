using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Infra.Data.Mapping;

public class ClientsMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("clients");
        builder.HasKey(prop => prop.Id);
        
        builder.Property(prop => prop.Id)
            .HasColumnName("id");
        builder.Property(prop => prop.Name)
            .HasColumnName("name");
        builder.Property(prop => prop.CreatedOn)
            .HasColumnName("created_on");
        builder.Property(prop => prop.LastName)
            .HasColumnName("last_name");
        builder.Property(prop => prop.IsActive)
            .HasColumnName("is_active");
        builder.Property(prop => prop.Phone)
            .HasColumnName("phone");
        builder.Property(prop => prop.Debt)
            .HasColumnName("debt");
        builder.Property(prop => prop.Credit)
            .HasColumnName("credit");
    }
}