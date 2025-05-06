using MediatR;

namespace ControlEscolarApi.Application.TiposPersonal.Events.TipoPersonalPrefijoActualizado;

public class TipoPersonalPrefijoActualizadoEvent(int id, string nuevoPrefijo) : INotification
{
  public int Id { get; } = id;
  public string NuevoPrefijo { get;} = nuevoPrefijo;
}