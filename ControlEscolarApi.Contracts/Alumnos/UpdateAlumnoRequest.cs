namespace ControlEscolarApi.Contracts.Alumnos;

/// <summary>
/// Request con datos necesarios para la actualización de un alumno
/// </summary>
public class UpdateAlumnoRequest {
    public int Id { get; set;}
    public string? Nombre { get; set;}
    public string? ApellidoPaterno { get; set;}
    public string? ApellidoMaterno { get; set;}
    public string? Correo { get; set;}= null!;
    public DateTime? FechaNacimiento { get; set;}
    public bool? Estatus { get; set;}
};
