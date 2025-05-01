using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Commands.UpdateAlumno;

public class UpdateAlumnoCommand : IRequest<ErrorOr<Alumno>> 
{
    public int Id { get; set;}
    public string? Nombre { get; set;}
    public string? ApellidoPaterno { get; set;}
    public string? ApellidoMaterno { get; set;}
    public string? Correo { get; set;}= null!;
    public DateTime? FechaNacimiento { get; set;}
    public bool? Estatus { get; set;}
};
