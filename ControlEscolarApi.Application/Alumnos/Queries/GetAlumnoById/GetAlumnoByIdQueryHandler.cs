using ControlEscolarApi.Application.Alumnos.Queries.GetAlumnos;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Queries.GetAlumnoById;

/// <summary>
/// Maneja la obtención de un alumno por su id.
/// </summary>
public class GetAlumnoByIdQueryHandler(
  IGenericRepository<Alumno> alumnoRepository ) : IRequestHandler<GetAlumnoByIdQuery, ErrorOr<Alumno>>
{
  IGenericRepository<Alumno> _alumnoRepository = alumnoRepository;
  public async Task<ErrorOr<Alumno>> Handle(GetAlumnoByIdQuery request, CancellationToken cancellationToken)
  {
    var result = await _alumnoRepository.GetByIdAsync(request.Id);

    if(result is null) {
        return Errors.Alumno.MissingAlumno;
    }

    return result;
  }
}
