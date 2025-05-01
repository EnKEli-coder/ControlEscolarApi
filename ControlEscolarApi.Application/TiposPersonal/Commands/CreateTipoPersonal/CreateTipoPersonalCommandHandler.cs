using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.CreateTipoPersonal;

public class CreateTipoPersonalCommandHandler(
  IGenericRepository<TipoPersonal> tipoPersonalRepository ) : IRequestHandler<CreateTipoPersonalCommand, ErrorOr<TipoPersonal>>
{

  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;
  public async Task<ErrorOr<TipoPersonal>> Handle(CreateTipoPersonalCommand request, CancellationToken cancellationToken)
  {

    if( await _tipoPersonalRepository.SelectAsync(tipos => tipos.Nombre == request.Nombre) is not null) {
      return Errors.TipoPersonal.DuplicatedName;
    }

    if( await _tipoPersonalRepository.SelectAsync(tipos => tipos.Prefijo == request.Prefijo) is not null) {
      return Errors.TipoPersonal.DuplicatedPrefix;
    }

    var tipoPersonal = new TipoPersonal {
      Prefijo = request.Prefijo,
      Nombre = request.Nombre,
      SueldoMaximo = request.SueldoMaximo,
      SueldoMinimo = request.SueldoMinimo
    };

    _tipoPersonalRepository.Add(tipoPersonal);
    await _tipoPersonalRepository.SaveAsync();
    return tipoPersonal;
  }
}
