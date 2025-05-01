using FluentValidation;

namespace ControlEscolarApi.Application.Personal.Commands.UpdatePersonal;

public class UpdatePersonalCommandValidator : AbstractValidator<UpdatePersonalCommand> {
    public UpdatePersonalCommandValidator() {

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El id es requerido");

        RuleFor(x => x.Nombre)
            .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

        RuleFor(x => x.ApellidoPaterno)
            .MaximumLength(50).WithMessage("El apellido paterno no puede exceder 50 caracteres");

        RuleFor(x => x.ApellidoMaterno)
            .MaximumLength(50).WithMessage("El apellido materno no puede exceder 50 caracteres");

        RuleFor(x => x.Correo)
            .EmailAddress().WithMessage("El correo electrónico no es válido")
            .MaximumLength(100).WithMessage("El correo electrónico no puede exceder 100 caracteres");

        RuleFor(x => x.FechaNacimiento)
            .LessThan(DateTime.Now.Date.AddYears(-18)).WithMessage("El personal debe ser mayor de 18 años")
            .GreaterThan(DateTime.Now.Date.AddYears(-100)).WithMessage("La fecha de nacimiento no es válida");

        RuleFor(x => x.Sueldo)
            .GreaterThan(0).WithMessage("El sueldo debe ser mayor a 0")
            .PrecisionScale(12, 2, true).WithMessage("El sueldo debe tener máximo 2 decimales y no más de 12 dígitos en total");
    }
}