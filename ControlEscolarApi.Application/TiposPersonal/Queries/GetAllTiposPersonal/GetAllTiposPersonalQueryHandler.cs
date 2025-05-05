using ControlEscolarApi.Application.Alumnos.Queries.GetAlumnoById;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Application.TiposPersonal.Queries.GetTipoPersonalById;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Queries.GetAllTiposPersonal;


/// <summary>
/// Maneja la obtención de todos los tipos de personal
/// </summary>
public class GetAllTiposPersonalQueryHandler(
  IGenericRepository<TipoPersonal> tipoPersonalRepository ) : IRequestHandler<GetAllTiposPersonalQuery, ErrorOr<List<TipoPersonal>>>
{
  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;
  public async Task<ErrorOr<List<TipoPersonal>>> Handle(GetAllTiposPersonalQuery request, CancellationToken cancellationToken)
  {
    var result = await _tipoPersonalRepository.GetAllAsync();

    if(result is null) {
        return Errors.TipoPersonal.MissingTipoPersonal;
    }

    return result;
  }
}
