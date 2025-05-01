using ControlEscolarApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlEscolarApi.Infrastructure.Persistence.Configurations;

public class TipoPersonalConfiguration : IEntityTypeConfiguration<TipoPersonal>
{
    public void Configure(EntityTypeBuilder<TipoPersonal> builder)
    {
        builder.ToTable("TiposPersonal");

        builder.HasKey(tipoPersonal => tipoPersonal.Id);

        builder.Property(tipoPersonal => tipoPersonal.Prefijo)
            .IsRequired()
            .HasMaxLength(10);
        builder.HasIndex(tipoPersonal => tipoPersonal.Prefijo)
            .IsUnique();

        builder.Property(tipoPersonal => tipoPersonal.Nombre)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(tipoPersonal => tipoPersonal.SueldoMinimo)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
        
        builder.Property(tipoPersonal => tipoPersonal.SueldoMaximo)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
    }
} 