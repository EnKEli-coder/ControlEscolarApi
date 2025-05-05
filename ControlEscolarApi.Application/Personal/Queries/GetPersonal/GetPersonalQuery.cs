using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Application.Personal.Common;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Queries.GetPersonal;

public class GetPersonalQuery : IRequest<ErrorOr<PaginatedList<PersonalResult>>>{

    public PaginationQueryParams QueryParams { get; set; } = null!;
}
