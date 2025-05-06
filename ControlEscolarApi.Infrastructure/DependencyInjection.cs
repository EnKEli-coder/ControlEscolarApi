using System.Text;
using ControlEscolarApi.Application.Authentication.Common.Interfaces;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Application.Services;
using ControlEscolarApi.Domain.Entities;
using ControlEscolarApi.Infrastructure.Authentication;
using ControlEscolarApi.Infrastructure.Persistence;
using ControlEscolarApi.Infrastructure.Persistence.Repositories;
using ControlEscolarApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ControlEscolarApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration) 
        {
            services.AddAuth(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddDbContext<ControlEscolarDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IGenericRepository<User>, UserRepository>();
            services.AddScoped<IGenericRepository<Alumno>, AlumnoRepository>();
            services.AddScoped<IGenericRepository<Personal>, PersonalRepository>();
            services.AddScoped<IGenericRepository<TipoPersonal>, TipoPersonalRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration
        ) {
            var JwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, JwtSettings);

            services.AddSingleton(Options.Create(JwtSettings));
            services.AddSingleton<IJwtTokenGenerator, jwtTokenGenerator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtSettings.Issuer,
                ValidAudience = JwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(JwtSettings.Secret)
                )
            });

            return services;
        }
    }
}