using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.DeleteTipoPersonal;

public class CreateTipoPersonalCommandHandler(
  IGenericRepository<TipoPersonal> tipoPersonalRepository ) : IRequestHandler<DeleteTipoPersonalCommand, ErrorOr<bool>>
{

  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;

  public async Task<ErrorOr<bool>> Handle(DeleteTipoPersonalCommand request, CancellationToken cancellationToken)
  {
    var tipoPersonal = await _tipoPersonalRepository.GetByIdAsync(request.Id);

    if( tipoPersonal is null) {
      return Errors.TipoPersonal.MissingTipoPersonal;
    }

    _tipoPersonalRepository.Remove(request.Id);

    await _tipoPersonalRepository.SaveAsync();

    return true;
  }
}
