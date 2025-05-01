using ControlEscolarApi.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Authentication.Queries.Login;

public record LoginQuery (
  string Email,
  string Password
) : IRequest<ErrorOr<AuthenticationResult>>;