namespace ControlEscolarApi.Application.Authentication.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerarToken(int id, string username);
}