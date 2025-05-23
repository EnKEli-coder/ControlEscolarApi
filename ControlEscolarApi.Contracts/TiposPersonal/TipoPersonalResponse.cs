namespace ControlEscolarApi.Contracts.TiposPersonal;


/// <summary>
/// Respuesta con los datos completos de tipo de personal
/// </summary>
public class TipoPersonalResponse {
  public int Id { get; set; }
  public string Prefijo { get; set;} = null!;
  public string Nombre { get; set;} = null!;
  public decimal SueldoMinimo { get; set;}
  public decimal SueldoMaximo { get; set;}
}