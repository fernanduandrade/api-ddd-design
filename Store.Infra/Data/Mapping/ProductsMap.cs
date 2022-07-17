using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Mapping;

public class ProductsMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Id)
            .HasColumnName("id");
        builder.Property(prop => prop.Name)
            .HasColumnName("name");
        builder.Property(prop => prop.Value)
            .HasColumnName("value");
        builder.Property(prop => prop.IsAvailable)
            .HasColumnName("is_available");
        builder.Property(prop => prop.Quantity)
            .HasColumnName("quantity");
        builder.Property(prop => prop.CreatedOn)
            .HasColumnName("created_on");
    }
}
