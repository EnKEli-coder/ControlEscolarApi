using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Api.Controllers;

/// <summary>
/// Controlador base con autorización
/// </summary>
[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
  /// <summary>
  /// Obtiene los errores y devuelve un Problem
  /// </summary>
  /// <returns></returns>
  protected IActionResult Problem(List<Error> errors) {
    
    HttpContext.Items["errors"] = errors;
    var firstError = errors[0];

    var statusCode = firstError.Type switch
    {
      ErrorType.Conflict => StatusCodes.Status409Conflict,
      ErrorType.Validation => StatusCodes.Status400BadRequest,
      ErrorType.NotFound => StatusCodes.Status404NotFound,
      _ => StatusCodes.Status500InternalServerError,
    };

    return Problem(statusCode: statusCode, title: firstError.Description);
  }
}