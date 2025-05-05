namespace ControlEscolarApi.Application.Personal.Common;

public class PersonalResult 
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string NumeroControl { get; set;} = null!;
    public int TipoPersonalId { get; set; }
    public string TipoPersonal {get; set;} = null!;
    public decimal Sueldo { get; set; }
}