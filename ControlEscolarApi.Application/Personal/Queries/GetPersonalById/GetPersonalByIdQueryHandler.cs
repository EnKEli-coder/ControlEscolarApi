using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Application.Personal.Common;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Application.Personal.Queries.GetPersonalById;

/// <summary>
/// Maneja la obtención de un personal por su id.
/// </summary>
public class GetPersonalQueryHandler(
  IGenericRepository<Domain.Entities.Personal> personalRepository ) : IRequestHandler<GetPersonalByIdQuery, ErrorOr<Domain.Entities.Personal>>
{
  IGenericRepository<Domain.Entities.Personal> _personalRepository = personalRepository;
  public async Task<ErrorOr<Domain.Entities.Personal>> Handle(GetPersonalByIdQuery request, CancellationToken cancellationToken)
  {
    var result = await _personalRepository.GetByIdAsync(request.Id);

    if(result is null) {
        return Errors.Personal.MissingPersonal;
    }

    return result;
  }
}
