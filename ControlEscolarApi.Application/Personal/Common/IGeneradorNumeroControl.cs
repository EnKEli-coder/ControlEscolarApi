namespace ControlEscolarApi.Application.Personal.Common;

public interface IGeneradorNumeroControl
{
  public string GenerarNumeroControl(string prefijo);
  public string RandomAlfaNumerico(int length);
}