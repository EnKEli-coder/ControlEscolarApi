namespace ControlEscolarApi.Contracts.Personal;

/// <summary>
/// Respuesta con datos de personal para mostrar en tabla
/// </summary>
public class PersonalResponse 
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string NumeroControl { get; set;} = null!;
    public int TipoPersonalId { get; set; }
    public string TipoPersonal {get; set;} = null!;
    public decimal Sueldo { get; set; }
}