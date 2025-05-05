using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Queries.GetAlumnoById;

public class GetAlumnoByIdQuery : IRequest<ErrorOr<Alumno>>{
    public int Id { get; set;}
}