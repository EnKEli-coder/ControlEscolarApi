namespace ControlEscolarApi.Domain.Entities;

public class Personal
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string ApellidoPaterno { get; set; } = null!;
    public string ApellidoMaterno { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public DateTime FechaNacimiento { get; set; }
    public string NumeroControl { get; set; } = null!;
    public float Sueldo { get; set; }
    public bool Estatus { get; set; }
    public int TipoPersonalId { get; set; }
}
