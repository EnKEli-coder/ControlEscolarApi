using ControlEscolarApi.Domain.Entities;
using FluentValidation;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.CreateTipoPersonal;

public class CreateAlumnoCommandValidator : AbstractValidator<CreateTipoPersonalCommand> {
    public CreateAlumnoCommandValidator() {
        RuleFor(x => x.Prefijo)
            .NotEmpty().WithMessage("El prefijo es requerido")
            .MaximumLength(10).WithMessage("El prefijo no puede exceder 10 caracteres");

        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es requerido")
            .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

        RuleFor(x => x.SueldoMinimo)
            .NotEmpty().WithMessage("El sueldo mínimo es requerido")
            .PrecisionScale(12, 2, true)
            .WithMessage("El sueldo mínimo debe tener máximo 2 decimales y no más de 12 dígitos en total");

        RuleFor(x => x.SueldoMaximo)
            .NotEmpty().WithMessage("El sueldo máximo es requerido")
            .PrecisionScale(12, 2, true).WithMessage("El sueldo máximo debe tener máximo 2 decimales y no más de 12 dígitos en total")
            .GreaterThan(x => x.SueldoMinimo).WithMessage("El sueldo máximo debe ser mayor que el mínimo");
    }
}