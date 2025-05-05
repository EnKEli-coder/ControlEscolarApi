using FluentValidation;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.UpdateTipoPersonal;

public class UpdatePersonalCommandValidator : AbstractValidator<UpdateTipoPersonalCommand> {
    public UpdatePersonalCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El id es requerido");

        RuleFor(x => x.Nombre)
            .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

        RuleFor(x => x.SueldoMinimo)
            .PrecisionScale(12, 2, true)
            .WithMessage("El sueldo mínimo debe tener máximo 2 decimales y no más de 12 dígitos en total");

        RuleFor(x => x.SueldoMaximo)
            .PrecisionScale(12, 2, true).WithMessage("El sueldo máximo debe tener máximo 2 decimales y no más de 12 dígitos en total")
            .GreaterThan(x => x.SueldoMinimo).WithMessage("El sueldo máximo debe ser mayor que el mínimo");
    }
}