using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Queries.GetAlumnos;

public class GetAlumnosQuery : IRequest<ErrorOr<List<Alumno>>>{}
