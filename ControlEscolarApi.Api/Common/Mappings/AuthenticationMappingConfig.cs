using AutoMapper;
using ControlEscolarApi.Application.Authentication.Common;
using ControlEscolarApi.Application.Authentication.Queries.Login;
using ControlEscolarApi.Contracts.Authentication;
using ControlEscolarApi.Domain.Entities;

namespace ControlEscolarApi.Api.Common.Mappings;

public class AuthenticationMappingConfig : Profile 
{
  public AuthenticationMappingConfig() 
  {
    CreateMap<LoginRequest, LoginQuery>();

    CreateMap<AuthenticationResult, AuthenticationResponse>()
      .ConstructUsing(src => new AuthenticationResponse(
          src.User.Id,
          src.User.Username,
          src.User.Email,
          src.Token
      ));
  }
}