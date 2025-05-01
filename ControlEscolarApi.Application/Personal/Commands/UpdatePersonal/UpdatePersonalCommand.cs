using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Commands.UpdatePersonal;

public class UpdatePersonalCommand : IRequest<ErrorOr<Domain.Entities.Personal>>
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
    public string? Correo { get; set; } = null!;
    public DateTime? FechaNacimiento { get; set; }
    public bool? Estatus { get; set; }
    public decimal? Sueldo { get; set; }
    public int? TipoPersonalId { get; set; }
}