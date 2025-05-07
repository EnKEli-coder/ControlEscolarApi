using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;

namespace ControlEscolarApi.Application.TiposPersonal.Events.TipoPersonalPrefijoActualizado;

public class TipoPersonalPrefijoActualizadoEventHandler(
  IGenericRepository<Domain.Entities.Personal> personalRepository
) : INotificationHandler<TipoPersonalPrefijoActualizadoEvent>
{

  IGenericRepository<Domain.Entities.Personal> _personalRepository = personalRepository;

  public async Task Handle(TipoPersonalPrefijoActualizadoEvent notification, CancellationToken cancellationToken)
  {
    await _personalRepository.ExecuteStoredProcedureAsync(
            "sp_ActualizarNumerosControl",
            new SqlParameter("TipoPersonalId", notification.Id),
            new SqlParameter("NuevoPrefijo", notification.NuevoPrefijo));
  }
}