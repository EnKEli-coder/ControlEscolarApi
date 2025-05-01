using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Commands.DeletePersonal;

public class DeletePersonalCommandHandler(
  IGenericRepository<Domain.Entities.Personal> personalRepository ) : IRequestHandler<DeletePersonalCommand, ErrorOr<bool>>
{
  IGenericRepository<Domain.Entities.Personal> _personalRepository = personalRepository;
 
  public async Task<ErrorOr<bool>> Handle(DeletePersonalCommand request, CancellationToken cancellationToken)
  {
    var personal = await _personalRepository.GetByIdAsync(request.Id);

    if( personal is null) {
      return Errors.Personal.MissingPersonal;
    }

    _personalRepository.Remove(request.Id);

    await _personalRepository.SaveAsync();

    return true;
  }
}