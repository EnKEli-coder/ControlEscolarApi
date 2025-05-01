using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Queries.GetTiposPersonal;

public class GetTiposPersonalQuery : IRequest<ErrorOr<PaginatedList<TipoPersonal>>>{

    public PaginationQueryParams QueryParams { get; set; } = null!;
}
