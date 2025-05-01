using FluentValidation;

namespace ControlEscolarApi.Application.Personal.Commands.CreatePersonal;

public class UpdatePersonalCommandValidator : AbstractValidator<CreatePersonalCommand> {
    public UpdatePersonalCommandValidator() {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es requerido")
            .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

        RuleFor(x => x.ApellidoPaterno)
            .NotEmpty().WithMessage("El apellido paterno es requerido")
            .MaximumLength(50).WithMessage("El apellido paterno no puede exceder 50 caracteres");

        RuleFor(x => x.ApellidoMaterno)
            .NotEmpty().WithMessage("El apellido materno es requerido")
            .MaximumLength(50).WithMessage("El apellido materno no puede exceder 50 caracteres");

        RuleFor(x => x.Correo)
            .NotEmpty().WithMessage("El correo electrónico es requerido")
            .EmailAddress().WithMessage("El correo electrónico no es válido")
            .MaximumLength(100).WithMessage("El correo electrónico no puede exceder 100 caracteres");

        RuleFor(x => x.FechaNacimiento)
            .NotEmpty().WithMessage("La fecha de nacimiento es requerida")
            .LessThan(DateTime.Now.Date.AddYears(-18)).WithMessage("El personal debe ser mayor de 18 años")
            .GreaterThan(DateTime.Now.Date.AddYears(-100)).WithMessage("La fecha de nacimiento no es válida");
            
        RuleFor(x => x.Estatus)
            .NotEmpty().WithMessage("El estatus es requerido");

        RuleFor(x => x.Sueldo)
            .NotEmpty().WithMessage("El sueldo es requerido")
            .GreaterThan(0).WithMessage("El sueldo debe ser mayor a 0")
            .PrecisionScale(12, 2, true).WithMessage("El sueldo debe tener máximo 2 decimales y no más de 12 dígitos en total");

        RuleFor(x => x.TipoPersonalId)
            .NotEmpty().WithMessage("El identificador del tipo de personal es requerido");
    }
}