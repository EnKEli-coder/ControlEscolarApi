using ControlEscolarApi.Domain.Entities;
using FluentValidation;

namespace ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;

public class CreateAlumnoCommandValidator : AbstractValidator<CreateAlumnoCommand> {
    public CreateAlumnoCommandValidator() {
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
    }
}