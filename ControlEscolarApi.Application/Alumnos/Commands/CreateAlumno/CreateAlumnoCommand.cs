using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;

public class CreateAlumnoCommand :  IRequest<ErrorOr<Alumno>>
{
    public string Nombre { get; set;} = null!;
    public string ApellidoPaterno { get; set;}= null!;
    public string ApellidoMaterno { get; set;}= null!;
    public string Correo { get; set;}= null!;
    public DateTime FechaNacimiento { get; set;}
    public bool Estatus { get; set;}
};