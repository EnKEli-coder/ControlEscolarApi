using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Queries.GetAlumnos;

public class GetAlumnosQueryHandler(
  IGenericRepository<Alumno> alumnoRepository ) : IRequestHandler<GetAlumnosQuery, ErrorOr<List<Alumno>>>
{
  IGenericRepository<Alumno> _alumnoRepository = alumnoRepository;
  public async Task<ErrorOr<List<Alumno>>> Handle(GetAlumnosQuery request, CancellationToken cancellationToken)
  {
    return await _alumnoRepository.GetAllAsync();
  }
}
