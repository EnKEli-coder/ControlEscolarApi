using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Commands.DeleteAlumno;

/// <summary>
/// Maneja la eliminación de un alumno
/// </summary>
public class DeleteAlumnoCommandHandler(
  IGenericRepository<Alumno> alumnoRepository ) : IRequestHandler<DeleteAlumnoCommand, ErrorOr<bool>>
{

  IGenericRepository<Alumno> _alumnoRepository = alumnoRepository;
  public async Task<ErrorOr<bool>> Handle(DeleteAlumnoCommand request, CancellationToken cancellationToken)
  {
    var alumno = await _alumnoRepository.GetByIdAsync(request.Id);

    if( alumno is null) {
      return Errors.Alumno.MissingAlumno;
    }

    _alumnoRepository.Remove(request.Id);

    await _alumnoRepository.SaveAsync();

    return true;
  }
}