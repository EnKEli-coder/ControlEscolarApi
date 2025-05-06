using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Application.TiposPersonal.Commands.DeleteTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Events.TipoPersonalPrefijoActualizado;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.UpdateTipoPersonal;

/// <summary>
/// Maneja la actualización de un tipo de personal, valida duplicados
/// </summary>
public class UpdateTipoPersonalCommandHandler(
  IGenericRepository<TipoPersonal> tipoPersonalRepository,
  IMediator mediator ) : IRequestHandler<UpdateTipoPersonalCommand, ErrorOr<TipoPersonal>>
{

  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;
  private readonly IMediator _mediator = mediator;

  public async Task<ErrorOr<TipoPersonal>> Handle(UpdateTipoPersonalCommand request, CancellationToken cancellationToken)
  {
    var tipoPersonal = await _tipoPersonalRepository.GetByIdAsync(request.Id);

    if( tipoPersonal is null) {
      return Errors.TipoPersonal.MissingTipoPersonal;
    }

    var prefijoAnterior = tipoPersonal.Prefijo;

    if (request.Nombre != null) {
      if( await _tipoPersonalRepository.SelectAsync(tipos => tipos.Nombre == request.Nombre && tipos.Id != request.Id) is not null) {
        return Errors.TipoPersonal.DuplicatedName;
      }
      tipoPersonal.Nombre = request.Nombre;
    }

    if (request.Prefijo != null) {
      if( await _tipoPersonalRepository.SelectAsync(tipos => tipos.Prefijo == request.Prefijo && tipos.Id != request.Id) is not null) {
        return Errors.TipoPersonal.DuplicatedPrefix;
      }
      tipoPersonal.Prefijo = request.Prefijo;
    }

    if (request.SueldoMaximo != null) {
        tipoPersonal.SueldoMaximo = request.SueldoMaximo.Value;
    }

    if (request.SueldoMinimo != null) {
        tipoPersonal.SueldoMinimo = request.SueldoMinimo.Value;
    }

    await _tipoPersonalRepository.SaveAsync();

    if(prefijoAnterior != tipoPersonal.Prefijo)
    {
      await _mediator.Publish(new TipoPersonalPrefijoActualizadoEvent(
        tipoPersonal.Id,
        tipoPersonal.Prefijo
      ));
    }

    return tipoPersonal;
  }
}
