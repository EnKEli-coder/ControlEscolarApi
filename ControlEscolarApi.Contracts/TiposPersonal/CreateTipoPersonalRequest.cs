namespace ControlEscolarApi.Contracts.TiposPersonal;

public class CreateTipoPersonalRequest {
  public string Prefijo { get; set;} = null!;
  public string Nombre { get; set;} = null!;
  public decimal SueldoMinimo { get; set;}
  public decimal SueldoMaximo { get; set;}
}