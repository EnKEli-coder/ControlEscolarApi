using System.Security.Cryptography.X509Certificates;

namespace ControlEscolarApi.Contracts.Alumnos;

/// <summary>
/// Respuesta con datos del alumno para mostrar en tabla
/// </summary>
public class AlumnoResponse {
    public int Id { get; set;}
    public string Nombre { get; set;} = null!;
    public string Correo { get; set;}= null!;
    public string NumeroControl { get; set;}= null!;
};
