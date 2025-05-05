using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Application.TiposPersonal.Commands.DeleteTipoPersonal;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.UpdateTipoPersonal;

public class UpdateTipoPersonalCommandHandler(
  IGenericRepository<TipoPersonal> tipoPersonalRepository ) : IRequestHandler<UpdateTipoPersonalCommand, ErrorOr<TipoPersonal>>
{

  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;

  public async Task<ErrorOr<TipoPersonal>> Handle(UpdateTipoPersonalCommand request, CancellationToken cancellationToken)
  {
    var tipoPersonal = await _tipoPersonalRepository.GetByIdAsync(request.Id);

    if( tipoPersonal is null) {
      return Errors.TipoPersonal.MissingTipoPersonal;
    }

    if (request.Nombre != null) {
      if( await _tipoPersonalRepository.SelectAsync(tipos => tipos.Nombre == request.Nombre && tipos.Id != request.Id) is not null) {
        return Errors.TipoPersonal.DuplicatedName;
      }
      tipoPersonal.Nombre = request.Nombre;
    }

    if (request.SueldoMaximo != null) {
        tipoPersonal.SueldoMaximo = request.SueldoMaximo.Value;
    }

    if (request.SueldoMinimo != null) {
        tipoPersonal.SueldoMinimo = request.SueldoMinimo.Value;
    }

    await _tipoPersonalRepository.SaveAsync();

    return tipoPersonal;
  }
}
