using ErrorOr;

namespace ControlEscolarApi.Domain.Common.Errors;

public static partial class Errors {
  public static class User
  {
    public static Error WrongCredentials => Error.Conflict(
      code: "User.WrongCredentials",
      description: "Credenciales incorrectas"
    );
  }
}
