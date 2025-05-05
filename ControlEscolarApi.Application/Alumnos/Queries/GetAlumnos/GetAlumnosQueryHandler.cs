using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Queries.GetAlumnos;

/// <summary>
/// Maneja la obtención alumnos con paginación
/// </summary>
public class GetAlumnosQueryHandler(
  IGenericRepository<Alumno> alumnoRepository ) : IRequestHandler<GetAlumnosQuery, ErrorOr<PaginatedList<AlumnoResult>>>
{
  IGenericRepository<Alumno> _alumnoRepository = alumnoRepository;
  public async Task<ErrorOr<PaginatedList<AlumnoResult>>> Handle(GetAlumnosQuery request, CancellationToken cancellationToken)
  {
    var query =  _alumnoRepository.GetAll(request.QueryParams)
      .Select(alumno => new AlumnoResult {
        Id = alumno.Id,
        Nombre = alumno.Nombre + " " + alumno.ApellidoPaterno + " " + alumno.ApellidoMaterno,
        Correo = alumno.Correo,
        NumeroControl = alumno.NumeroControl
      } );
   
    var result = await PaginatedList<AlumnoResult>.CreateAsync(query, request.QueryParams.Page , request.QueryParams.PageSize);

    return result;
  }
}
