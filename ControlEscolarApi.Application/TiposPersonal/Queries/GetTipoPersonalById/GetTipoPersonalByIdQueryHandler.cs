using ControlEscolarApi.Application.Alumnos.Queries.GetAlumnoById;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Queries.GetTipoPersonalById;

public class GetTipoPersonalByIdQueryHandler(
  IGenericRepository<TipoPersonal> tipoPersonalRepository ) : IRequestHandler<GetTipoPersonalByIdQuery, ErrorOr<TipoPersonal>>
{
  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;
  public async Task<ErrorOr<TipoPersonal>> Handle(GetTipoPersonalByIdQuery request, CancellationToken cancellationToken)
  {
    var result = await _tipoPersonalRepository.GetByIdAsync(request.Id);

    if(result is null) {
        return Errors.TipoPersonal.MissingTipoPersonal;
    }

    return result;
  }
}
