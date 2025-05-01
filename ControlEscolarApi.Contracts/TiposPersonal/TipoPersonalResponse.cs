namespace ControlEscolarApi.Contracts.TiposPersonal;

public class TipoPersonalResponse {
  public int Id { get; set; }
  public string Prefijo { get; set;} = null!;
  public string Nombre { get; set;} = null!;
  public float SueldoMinimo { get; set;}
  public float SueldoMaximo { get; set;}
}