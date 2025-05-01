using System.Reflection;
using ControlEscolarApi.Application.Authentication.Common;
using ControlEscolarApi.Application.Authentication.Queries.Login;
using ControlEscolarApi.Application.Common.Behaviors;
using ControlEscolarApi.Application.Personal.Common;
using ControlEscolarApi.Application.Services;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ControlEscolarApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddSingleton<IGeneradorNumeroControl, GeneradorNumeroControl>();
           
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}