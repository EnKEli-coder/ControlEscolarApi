using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using ControlEscolarApi.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;

public class CreateAlumnoCommandHandler(
  IGenericRepository<Alumno> alumnoRepository )  : IRequestHandler<CreateAlumnoCommand, ErrorOr<AlumnoResult>>
{
  private readonly IGenericRepository<Alumno> _alumnoRepository = alumnoRepository;

  public async Task<ErrorOr<AlumnoResult>> Handle(CreateAlumnoCommand request, CancellationToken cancellationToken)
  {
    if( await _alumnoRepository.SelectAsync(alumno => alumno.Correo == request.Correo) is not null) {
      return Errors.Alumno.DuplicatedEmail;;
    }

    var numeroControl = GenerarNumeroControAlumno();

    var alumno = new Alumno {
      Nombre = request.Nombre,
      ApellidoPaterno = request.ApellidoPaterno,
      ApellidoMaterno = request.ApellidoMaterno,
      Correo = request.Correo,
      NumeroControl = numeroControl,
      FechaNacimiento = request.FechaNacimiento,
      Estatus = request.Estatus,
    };

    _alumnoRepository.Add(alumno);
    await _alumnoRepository.SaveAsync();

    var alumnoResult =  new AlumnoResult {
        Id = alumno.Id,
        Nombre = alumno.Nombre + " " + alumno.ApellidoPaterno + " " + alumno.ApellidoMaterno,
        Correo = alumno.Correo,
        NumeroControl = alumno.NumeroControl
    };

    return alumnoResult;
  }

  public static string GenerarNumeroControAlumno()
  {
    var random = new Random();
    return random.Next(10000000, 99999999).ToString();
  }
}