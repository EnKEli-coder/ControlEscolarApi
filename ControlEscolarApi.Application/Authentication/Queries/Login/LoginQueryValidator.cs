using FluentValidation;

namespace ControlEscolarApi.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
  public LoginQueryValidator()
  {
    RuleFor(x => x.Email)
    .NotEmpty().WithMessage("El correo electronico es requerido")
    .EmailAddress().WithMessage("El correo electronico no es valido")
    .MaximumLength(100).WithMessage("El correo electrónico no puede exceder 100 caracteres");

    RuleFor(x => x.Password)
    .NotEmpty().WithMessage("La contraseña es requerida");
  }
}