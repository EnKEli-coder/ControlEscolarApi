using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.UpdateTipoPersonal;
public class UpdateTipoPersonalCommand :  IRequest<ErrorOr<TipoPersonal>>{

  public int Id { get; set; }
  public string? Prefijo { get; set;}
  public string? Nombre { get; set;}
  public float? SueldoMinimo { get; set;}
  public float? SueldoMaximo { get; set;}
}

