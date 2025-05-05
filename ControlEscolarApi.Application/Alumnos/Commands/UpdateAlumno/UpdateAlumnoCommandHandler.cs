using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Commands.UpdateAlumno;

/// <summary>
/// Maneja la actualización de un alumno, valida duplicados.
/// </summary>
public class UpdateAlumnoCommandHandler(
  IGenericRepository<Alumno> alumnoRepository) : IRequestHandler<UpdateAlumnoCommand, ErrorOr<AlumnoResult>>
{

  IGenericRepository<Alumno> _alumnoRepository = alumnoRepository;
  public async Task<ErrorOr<AlumnoResult>> Handle(UpdateAlumnoCommand request, CancellationToken cancellationToken)
  {
    var alumno = await _alumnoRepository.GetByIdAsync(request.Id);

    if (alumno is null)
    {
      return Errors.Alumno.MissingAlumno;
    }

    if (request.Nombre != null)
    {
      alumno.Nombre = request.Nombre;
    }

    if (request.ApellidoPaterno != null)
    {
      alumno.ApellidoPaterno = request.ApellidoPaterno;
    }

    if (request.ApellidoMaterno != null)
    {
      alumno.ApellidoMaterno = request.ApellidoMaterno;
    }

    if (request.Correo != null)
    {

      if (await _alumnoRepository.SelectAsync(alumno => alumno.Correo == request.Correo & alumno.Id != request.Id) is not null)
      {
        return Errors.Alumno.DuplicatedEmail;
      }

      alumno.Correo = request.Correo;
    }

    if (request.FechaNacimiento != null)
    {
      alumno.FechaNacimiento = request.FechaNacimiento.Value;
    }

    if (request.Estatus != null)
    {
      alumno.Estatus = request.Estatus.Value;
    }

    await _alumnoRepository.SaveAsync();

    var alumnoResult = new AlumnoResult
    {
      Id = alumno.Id,
      Nombre = alumno.Nombre + " " + alumno.ApellidoPaterno + " " + alumno.ApellidoMaterno,
      Correo = alumno.Correo,
      NumeroControl = alumno.NumeroControl
    };

    return alumnoResult;
  }
}