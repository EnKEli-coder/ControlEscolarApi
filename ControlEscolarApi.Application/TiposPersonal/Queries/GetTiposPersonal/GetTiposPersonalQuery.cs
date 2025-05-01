using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Queries.GetTiposPersonal;

public class GetTiposPersonalQuery : IRequest<ErrorOr<List<TipoPersonal>>>{}
