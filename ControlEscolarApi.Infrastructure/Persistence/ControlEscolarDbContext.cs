using ControlEscolarApi.Domain.Entities;
using ControlEscolarApi.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Infrastructure.Persistence;

public class ControlEscolarDbContext : DbContext
{
    public DbSet<TipoPersonal> TiposPersonal { get; set; } =  null!;
    public DbSet<Personal> Personal { get; set; } =  null!;
    public DbSet<User> Users { get; set; } =  null!;
    public DbSet<Alumno> Alumnos { get; set; } =  null!;

    public ControlEscolarDbContext(DbContextOptions<ControlEscolarDbContext> options)
    : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new TipoPersonalConfiguration().Configure(modelBuilder.Entity<TipoPersonal>());
        new PersonalConfiguration().Configure(modelBuilder.Entity<Personal>());
        new AlumnoConfiguration().Configure(modelBuilder.Entity<Alumno>());
    }
    
}
