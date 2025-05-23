namespace ControlEscolarApi.Contracts.Personal;

/// <summary>
/// Respuesta con datos completos de personal
/// </summary>
public class PersonalDetailedResponse 
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string ApellidoPaterno { get; set; } = null!;
    public string ApellidoMaterno { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string NumeroControl { get; set;} = null!;
    public int TipoPersonalId { get; set; }
    public string TipoPersonal {get; set;} = null!;
    public decimal Sueldo { get; set; }
}