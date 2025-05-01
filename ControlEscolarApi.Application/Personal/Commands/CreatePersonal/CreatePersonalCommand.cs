using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Commands.CreatePersonal;

public class CreatePersonalCommand : IRequest<ErrorOr<Domain.Entities.Personal>>
{
    public string Nombre { get; set; } = null!;
    public string ApellidoPaterno { get; set; } = null!;
    public string ApellidoMaterno { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public bool Estatus { get; set; }
    public decimal Sueldo { get; set; }
    public int TipoPersonalId { get; set; }
}