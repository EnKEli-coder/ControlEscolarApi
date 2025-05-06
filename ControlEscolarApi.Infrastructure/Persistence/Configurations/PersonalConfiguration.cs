using ControlEscolarApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlEscolarApi.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuración de la entidad Personal a la tabla en base de datos
/// </summary>
public class PersonalConfiguration : IEntityTypeConfiguration<Personal>
{

    public void Configure(EntityTypeBuilder<Personal> builder)
    {
        builder.HasKey(personal => personal.Id);

        builder.Property(personal => personal.Nombre)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(personal => personal.ApellidoPaterno)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(personal => personal.ApellidoMaterno)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(personal => personal.Correo)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(personal => personal.Correo)
            .IsUnique();
        
        builder.Property(personal => personal.FechaNacimiento)
            .IsRequired();
        
        builder.Property(personal => personal.NumeroControl)
            .IsRequired()
            .HasMaxLength(26);
        builder.HasIndex(personal => personal.NumeroControl)
            .IsUnique();
        
        builder.Property(personal => personal.Sueldo)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
        
        builder.Property(personal => personal.Estatus)
            .IsRequired();  

        builder.HasOne(personal => personal.TipoPersonal)
            .WithMany()
            .HasForeignKey(personal => personal.TipoPersonalId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.Property(e => e.FechaCreacion)
            .HasDefaultValueSql("GETUTCDATE()");

        
    }
} 