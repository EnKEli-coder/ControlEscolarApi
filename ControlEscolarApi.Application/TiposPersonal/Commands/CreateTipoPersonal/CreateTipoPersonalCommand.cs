using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.CreateTipoPersonal;

public class CreateTipoPersonalCommand : IRequest<ErrorOr<TipoPersonal>> 
{
  public string Prefijo { get; set;} = null!;
  public string Nombre { get; set;} = null!;
  public float SueldoMinimo { get; set;}
  public float SueldoMaximo { get; set;}
}
