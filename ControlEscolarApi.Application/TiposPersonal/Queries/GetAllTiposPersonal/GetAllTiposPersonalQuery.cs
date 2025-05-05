using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Queries.GetTipoPersonalById;

public class GetAllTiposPersonalQuery : IRequest<ErrorOr<List<TipoPersonal>>>{}