using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Api.Controllers;

/// <summary>
/// Controlador para fallback de errores
/// </summary>
[Route("[controller]")]
public class ErrorController : ControllerBase 
{

  /// <summary>
  /// Obtiene excepciones y las convierte en un Problem
  /// </summary>
  /// <returns>Problem</returns>
  [HttpGet]
  public IActionResult Error() {

    Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    return Problem(title: exception?.Message);
  }
}