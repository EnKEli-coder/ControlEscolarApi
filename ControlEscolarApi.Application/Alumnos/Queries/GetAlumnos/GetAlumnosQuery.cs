using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Alumnos.Queries.GetAlumnos;

public class GetAlumnosQuery : IRequest<ErrorOr<PaginatedList<AlumnoResult>>>{
    public PaginationQueryParams QueryParams { get; set; } = null!;
}
