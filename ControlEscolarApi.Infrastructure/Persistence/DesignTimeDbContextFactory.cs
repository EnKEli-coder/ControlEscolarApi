using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ControlEscolarApi.Infrastructure.Persistence;

/// <summary>
/// Configuración para generar las migraciones
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ControlEscolarDbContext>
{
    public ControlEscolarDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ControlEscolarDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=ControlEscolarDb;Trusted_Connection=True;TrustServerCertificate=True;");

        return new ControlEscolarDbContext(optionsBuilder.Options);
    }
}