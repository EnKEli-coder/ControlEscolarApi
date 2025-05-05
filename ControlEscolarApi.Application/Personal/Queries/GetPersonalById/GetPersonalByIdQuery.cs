using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Queries.GetPersonalById;

public class GetPersonalByIdQuery : IRequest<ErrorOr<Domain.Entities.Personal>>{
    public int Id { get; set;}
}