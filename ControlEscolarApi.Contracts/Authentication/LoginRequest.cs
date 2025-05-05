namespace ControlEscolarApi.Contracts.Authentication;


/// <summary>
/// Request para hacer login
/// </summary>
public record LoginRequest (
  string Email,
  string Password
);