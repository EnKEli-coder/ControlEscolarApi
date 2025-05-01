using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using ControlEscolarApi.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;

public class CreateAlumnoCommandHandler(
  IGenericRepository<Alumno> alumnoRepository )  : IRequestHandler<CreateAlumnoCommand, ErrorOr<Alumno>>
{
  private readonly IGenericRepository<Alumno> _alumnoRepository = alumnoRepository;

  public async Task<ErrorOr<Alumno>> Handle(CreateAlumnoCommand request, CancellationToken cancellationToken)
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
    return alumno;
  }

  public static string GenerarNumeroControAlumno()
  {
    var random = new Random();
    return random.Next(10000000, 99999999).ToString();
  }
}