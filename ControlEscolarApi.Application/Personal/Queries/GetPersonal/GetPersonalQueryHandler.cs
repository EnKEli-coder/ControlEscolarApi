using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Application.Personal.Common;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Application.Personal.Queries.GetPersonal;

/// <summary>
/// Maneja la obtención de personal con paginación.
/// </summary>
public class GetPersonalQueryHandler(
  IGenericRepository<Domain.Entities.Personal> personalRepository ) : IRequestHandler<GetPersonalQuery, ErrorOr<PaginatedList<PersonalResult>>>
{
  IGenericRepository<Domain.Entities.Personal> _personalRepository = personalRepository;
  public async Task<ErrorOr<PaginatedList<PersonalResult>>> Handle(GetPersonalQuery request, CancellationToken cancellationToken)
  {
    var query =  _personalRepository.GetAll(request.QueryParams)
      .Include(p => p.TipoPersonal)
      .Select(p => new PersonalResult
      {
          Id = p.Id,
          Nombre = p.Nombre + " " + p.ApellidoPaterno + " " + p.ApellidoMaterno,
          Correo =p.Correo,
          NumeroControl = p.NumeroControl,
          TipoPersonalId = p.TipoPersonalId,
          TipoPersonal = p.TipoPersonal.Nombre,
          Sueldo = p.Sueldo
      });

    var result = await PaginatedList<PersonalResult>.CreateAsync(query, request.QueryParams.Page , request.QueryParams.PageSize);

    return result;
  }
}
