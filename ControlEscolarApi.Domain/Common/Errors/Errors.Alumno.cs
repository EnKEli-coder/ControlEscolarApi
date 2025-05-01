using ErrorOr;

namespace ControlEscolarApi.Domain.Common.Errors;

public static partial class Errors {
  public static class Alumno
  {
    public static Error DuplicatedEmail => Error.Conflict(
      code: "Alumno.DeplicatedEmail",
      description: "Ya hay un alumno con este correo"
    );

    public static Error MissingAlumno => Error.NotFound(
      code: "Alumno.NotFound",
      description: "No se encontró el alumno"
    );
  }
}
