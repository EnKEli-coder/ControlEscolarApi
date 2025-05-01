namespace ControlEscolarApi.Contracts.TiposPersonal;

public class UpdateTipoPersonalRequest {

  public int Id { get; set; }
  public string? Prefijo { get; set;}
  public string? Nombre { get; set;}
  public float? SueldoMinimo { get; set;}
  public float? SueldoMaximo { get; set;}
}
