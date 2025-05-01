using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Commands.DeleteTipoPersonal;

public class DeleteTipoPersonalCommand:  IRequest<ErrorOr<bool>> {
  public int Id { get; set;}
}
