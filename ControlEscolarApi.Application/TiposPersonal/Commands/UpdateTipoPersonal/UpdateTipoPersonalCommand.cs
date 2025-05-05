using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.UpdateTipoPersonal;
public class UpdateTipoPersonalCommand :  IRequest<ErrorOr<TipoPersonal>>{

  public int Id { get; set; }
  public string? Nombre { get; set;}
  public decimal? SueldoMinimo { get; set;}
  public decimal? SueldoMaximo { get; set;}
}

