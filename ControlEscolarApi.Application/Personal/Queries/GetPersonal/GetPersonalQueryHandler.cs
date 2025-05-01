using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Queries.GetPersonal;

public class GetPersonalQueryHandler(
  IGenericRepository<Domain.Entities.Personal> personalRepository ) : IRequestHandler<GetPersonalQuery, ErrorOr<PaginatedList<Domain.Entities.Personal>>>
{
  IGenericRepository<Domain.Entities.Personal> _personalRepository = personalRepository;

  public async Task<ErrorOr<PaginatedList<Domain.Entities.Personal>>> Handle(GetPersonalQuery request, CancellationToken cancellationToken)
  {
    var query =  _personalRepository.GetAll(request.QueryParams);

    var result = await PaginatedList<Domain.Entities.Personal>.CreateAsync(query, request.QueryParams.Page , request.QueryParams.PageSize);

    return result;
  }
}
