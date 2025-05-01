using ErrorOr;

namespace ControlEscolarApi.Domain.Common.Errors;

public static partial class Errors {
  public static class TipoPersonal
  {

    public static Error MissingTipoPersonal => Error.NotFound(
      code: "TipoPersonal.NotFound",
      description: "No se encontró el tipo de personal"
    );

    public static Error DuplicatedName => Error.Conflict(
      code: "TipoPersonal.DuplicatedName",
      description: "Ya hay un tipo de personal con ese nombre"
    );

     public static Error DuplicatedPrefix => Error.Conflict(
      code: "TipoPersonal.DuplicatedPrefix",
      description: "Ya hay un tipo de personal con ese prefijo"
    );
  }
}
