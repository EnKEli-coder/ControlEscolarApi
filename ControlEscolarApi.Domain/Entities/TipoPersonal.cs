namespace ControlEscolarApi.Domain.Entities;

public class TipoPersonal
{
    public int Id { get; set;}
    public string Prefijo { get; set; } = null!;
    public string Nombre { get; set;} = null!;
    public decimal SueldoMinimo { get; set;}
    public decimal SueldoMaximo { get; set;}
}
