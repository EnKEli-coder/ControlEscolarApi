using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.CreateTipoPersonal;

public class CreateTipoPersonalCommand : IRequest<ErrorOr<TipoPersonal>> 
{
  public string Prefijo { get; set;} = null!;
  public string Nombre { get; set;} = null!;
  public decimal SueldoMinimo { get; set;}
  public decimal SueldoMaximo { get; set;}
}
