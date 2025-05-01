using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Queries.GetTiposPersonal;

public class GetTiposPersonalQueryHandler(
  IGenericRepository<TipoPersonal> tipoPersonalRepository ) : IRequestHandler<GetTiposPersonalQuery, ErrorOr<List<TipoPersonal>>>
{

  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;
  public async Task<ErrorOr<List<TipoPersonal>>> Handle(GetTiposPersonalQuery request, CancellationToken cancellationToken)
  {
    return await _tipoPersonalRepository.GetAllAsync();
  }
}
