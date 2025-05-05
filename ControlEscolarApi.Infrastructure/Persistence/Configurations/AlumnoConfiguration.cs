using ControlEscolarApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlEscolarApi.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuración de la entidad Alumno a la tabla en base de datos
/// </summary>
public class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        builder.ToTable("Alumnos");

        builder.HasKey(alumno => alumno.Id);

        builder.Property(alumno => alumno.Nombre)
            .IsRequired()
            .HasMaxLength(100);
       
        builder.Property(alumno => alumno.ApellidoPaterno)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(alumno => alumno.ApellidoMaterno)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(alumno => alumno.Correo)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(alumno => alumno.Correo)
            .IsUnique();
        
        builder.Property(alumno => alumno.FechaNacimiento)
            .IsRequired();
        
        builder.Property(alumno => alumno.NumeroControl)
            .IsRequired()
            .HasMaxLength(8);
        builder.HasIndex(alumno => alumno.NumeroControl)
            .IsUnique();
        
        builder.Property(alumno => alumno.Estatus)
            .IsRequired(); 
            
        builder.Property(e => e.FechaCreacion)
            .HasDefaultValueSql("GETUTCDATE()");
    }
} 