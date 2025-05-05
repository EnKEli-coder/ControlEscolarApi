using ErrorOr;

namespace ControlEscolarApi.Domain.Common.Errors;

public static partial class Errors
{

  /// <summary>
  /// Errores esperados de la entidad Usuario
  /// </summary>
  public static class User
  {
    public static Error WrongCredentials => Error.Conflict(
      code: "User.WrongCredentials",
      description: "Credenciales incorrectas"
    );
  }
}
