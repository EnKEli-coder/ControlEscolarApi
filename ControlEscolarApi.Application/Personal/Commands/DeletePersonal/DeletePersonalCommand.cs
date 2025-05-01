using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Commands.DeletePersonal;

public class DeletePersonalCommand : IRequest<ErrorOr<bool>>
{
    public int Id { get; set; }
}
