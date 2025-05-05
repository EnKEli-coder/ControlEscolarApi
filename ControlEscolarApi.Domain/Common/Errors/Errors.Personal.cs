using ErrorOr;

namespace ControlEscolarApi.Domain.Common.Errors;

public static partial class Errors
{

  /// <summary>
  /// Errores esperados de la entidad personal
  /// </summary>
  public static class Personal
  {
    public static Error DuplicatedEmail => Error.Conflict(
      code: "Personal.DeplicatedEmail",
      description: "Ya hay un personal con este correo"
    );

    public static Error MissingPersonal => Error.NotFound(
      code: "Personal.NotFound",
      description: "No se encontró el personal"
    );

    public static Error WrongSueldo => Error.Conflict(
      code: "Personal.WrongSueldo",
      description: "El sueldo esta fuera de los limites permitidos."
    );
  }
}
