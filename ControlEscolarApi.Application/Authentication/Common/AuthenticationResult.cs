using ControlEscolarApi.Domain.Entities;

namespace ControlEscolarApi.Application.Authentication.Common;

public record AuthenticationResult
(
    User User,
    string Token
);