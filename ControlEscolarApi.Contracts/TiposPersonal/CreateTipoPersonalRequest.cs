namespace ControlEscolarApi.Contracts.TiposPersonal;

/// <summary>
/// Request con datos necesarios para la creación de un Tipo de personal
/// </summary>
public class CreateTipoPersonalRequest {
  public string Prefijo { get; set;} = null!;
  public string Nombre { get; set;} = null!;
  public decimal SueldoMinimo { get; set;}
  public decimal SueldoMaximo { get; set;}
}