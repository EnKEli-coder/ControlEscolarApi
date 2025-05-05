namespace ControlEscolarApi.Contracts.Authentication;


/// <summary>
/// Respuesta del login
/// </summary>
public record AuthenticationResponse (
  int Id,
  string Username, 
  string Email, 
  string Token
);