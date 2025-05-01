using ControlEscolarApi.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Queries.GetPersonal;

public class GetPersonalQueryHandler(
  IGenericRepository<Domain.Entities.Personal> personalRepository ) : IRequestHandler<GetPersonalQuery, ErrorOr<List<Domain.Entities.Personal>>>
{
  IGenericRepository<Domain.Entities.Personal> _personalRepository = personalRepository;

  public async Task<ErrorOr<List<Domain.Entities.Personal>>> Handle(GetPersonalQuery request, CancellationToken cancellationToken)
  {
    return await _personalRepository.GetAllAsync();
  }
}
