using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Queries.GetTiposPersonal;

/// <summary>
/// Maneja la obtención de tipos de personal con paginación
/// </summary>
public class GetTiposPersonalQueryHandler(
  IGenericRepository<TipoPersonal> tipoPersonalRepository ) : IRequestHandler<GetTiposPersonalQuery, ErrorOr<PaginatedList<TipoPersonal>>>
{

  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;
  public async Task<ErrorOr<PaginatedList<TipoPersonal>>> Handle(GetTiposPersonalQuery request, CancellationToken cancellationToken)
  {
    var query =  _tipoPersonalRepository.GetAll(request.QueryParams);

    var result = await PaginatedList<TipoPersonal>.CreateAsync(query, request.QueryParams.Page , request.QueryParams.PageSize);

    return result;
  }
}
