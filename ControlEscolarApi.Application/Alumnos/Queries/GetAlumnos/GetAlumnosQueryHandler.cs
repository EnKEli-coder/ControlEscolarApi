using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Queries.GetAlumnos;

public class GetAlumnosQueryHandler(
  IGenericRepository<Alumno> alumnoRepository ) : IRequestHandler<GetAlumnosQuery, ErrorOr<PaginatedList<Alumno>>>
{
  IGenericRepository<Alumno> _alumnoRepository = alumnoRepository;
  public async Task<ErrorOr<PaginatedList<Alumno>>> Handle(GetAlumnosQuery request, CancellationToken cancellationToken)
  {
    var query =  _alumnoRepository.GetAll(request.QueryParams);

    var result = await PaginatedList<Alumno>.CreateAsync(query, request.QueryParams.Page , request.QueryParams.PageSize);

    return result;
  }
}
