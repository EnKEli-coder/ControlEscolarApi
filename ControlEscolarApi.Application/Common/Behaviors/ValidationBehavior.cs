using System.Net;
using ControlEscolarApi.Application.Authentication.Common;
using ControlEscolarApi.Application.Authentication.Queries.Login;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace ControlEscolarApi.Application.Common.Behaviors;

/// <summary>
/// Maneja el flujo de validaciones de los comandos y queries.
/// </summary>
public class ValidateBehavior<TRequest, TResponse>(
  IValidator<TRequest>? validator = null
) :
  IPipelineBehavior<TRequest, TResponse>
  where TRequest : IRequest<TResponse>
  where TResponse : IErrorOr
{
  private readonly IValidator<TRequest>? _validator = validator;

  public async Task<TResponse> Handle(TRequest request, 
  RequestHandlerDelegate<TResponse> next, 
  CancellationToken cancellationToken)
  {

    if(_validator is null) {
      return await next(cancellationToken);
    }

    var validationResult = await _validator.ValidateAsync(request, cancellationToken);

    if(validationResult.IsValid) {
      return await next(cancellationToken);
    }

    var errors = validationResult.Errors
    .ConvertAll(error => Error.Validation(
      error.PropertyName,
      error.ErrorMessage
    ));
    return (dynamic)errors;
  }

}