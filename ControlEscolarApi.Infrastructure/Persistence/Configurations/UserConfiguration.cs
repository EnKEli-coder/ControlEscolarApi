using ControlEscolarApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlEscolarApi.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuración de la entidad User a la tabla en base de datos
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.Property(user => user.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(user => user.Password)
            .IsRequired()
            .HasMaxLength(255);    
    }
} 