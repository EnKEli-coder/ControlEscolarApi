using System.Security.Cryptography;
using System.Text;
using ControlEscolarApi.Application.Authentication.Common;
using ControlEscolarApi.Application.Authentication.Common.Interfaces;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
  IJwtTokenGenerator jwtTokenGenerator,
  IGenericRepository<User> userRepository) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

  private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
  private readonly IGenericRepository<User> _userRepository = userRepository;

  public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
  {
    var usuario = await _userRepository.SelectAsync(user => user.Email == request.Email);

    if(usuario is null) {
      return Errors.User.WrongCredentials;
    }

    var hashed  = Hashear(request.Password);

    if(hashed != usuario.Password) {
      return Errors.User.WrongCredentials;
    }

    var token = _jwtTokenGenerator.GenerarToken(usuario.Id, usuario.Username);

    return new AuthenticationResult(
      usuario,
      token
    );
  }

  public static string Hashear(string password)
  {
      var bytes = Encoding.UTF8.GetBytes(password);
      var hash = SHA256.HashData(bytes);
      return Convert.ToHexStringLower(hash);
  }
}