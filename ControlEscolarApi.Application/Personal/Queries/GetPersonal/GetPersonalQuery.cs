using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Common.QueryParams;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Queries.GetPersonal;

public class GetPersonalQuery : IRequest<ErrorOr<PaginatedList<Domain.Entities.Personal>>>{

    public PaginationQueryParams QueryParams { get; set; } = null!;
}
