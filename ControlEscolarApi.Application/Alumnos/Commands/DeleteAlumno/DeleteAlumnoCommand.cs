using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Commands.DeleteAlumno;

public class DeleteAlumnoCommand : IRequest<ErrorOr<bool>> 
{
  public int Id { get; set;}
};
