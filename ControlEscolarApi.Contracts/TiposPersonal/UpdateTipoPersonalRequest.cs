namespace ControlEscolarApi.Contracts.TiposPersonal;

/// <summary>
/// Request con datos necesarios para la actualización de un personal
/// </summary>
public class UpdateTipoPersonalRequest {

  public int Id { get; set; }
  public string? Nombre { get; set;}
  public string? Prefijo { get; set; }
  public decimal? SueldoMinimo { get; set;}
  public decimal? SueldoMaximo { get; set;}

}
