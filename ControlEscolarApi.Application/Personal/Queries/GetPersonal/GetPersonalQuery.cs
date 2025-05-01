using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Queries.GetPersonal;

public class GetPersonalQuery : IRequest<ErrorOr<List<Domain.Entities.Personal>>>{}
