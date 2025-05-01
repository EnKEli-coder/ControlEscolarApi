using ControlEscolarApi.Domain.Entities;
using FluentValidation;

namespace ControlEscolarApi.Application.Alumnos.Commands.UpdateAlumno;

public class UpdateAlumnoCommandValidator : AbstractValidator<UpdateAlumnoCommand> {
    
    public UpdateAlumnoCommandValidator() {

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El Id es requerido");

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
    }
}