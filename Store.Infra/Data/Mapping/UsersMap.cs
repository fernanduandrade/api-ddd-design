using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Mapping;

public class UsersMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Id)
            .HasColumnName("id");
        builder.Property(prop => prop.Email)
            .HasColumnName("email");
        builder.Property(prop => prop.Name)
            .HasColumnName("name");
        builder.Property(prop => prop.Password)
            .HasColumnName("password");
        builder.Property(prop => prop.CreatedOn)
            .HasColumnName("created_on");
    }
}