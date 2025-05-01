namespace ControlEscolarApi.Contracts.Personal;

public class PersonalResponse 
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string ApellidoPaterno { get; set; } = null!;
    public string ApellidoMaterno { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string NumeroControl { get; set;} = null!;
    public bool Estatus { get; set; }
    public decimal Sueldo { get; set; }
    public int TipoPersonalId { get; set; }
}