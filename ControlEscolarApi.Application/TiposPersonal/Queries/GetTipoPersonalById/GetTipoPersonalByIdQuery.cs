using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Queries.GetTipoPersonalById;

public class GetTipoPersonalByIdQuery : IRequest<ErrorOr<TipoPersonal>>{
    public int Id { get; set;}
}