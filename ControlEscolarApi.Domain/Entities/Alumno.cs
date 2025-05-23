namespace ControlEscolarApi.Domain.Entities;

public class Alumno
{
    public int Id {get; set;}
    public string Nombre {get; set;} = null!;
    public string ApellidoPaterno {get; set;} = null!;
    public string ApellidoMaterno {get; set;} = null!;
    public string Correo {get; set;} = null!;
    public DateTime FechaNacimiento {get; set;}
    public string NumeroControl {get; set;} = null!;
    public bool Estatus {get; set;}
    public DateTime FechaCreacion { get; set; }
}
