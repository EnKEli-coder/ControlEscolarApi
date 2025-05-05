using System;

namespace ControlEscolarApi.Application.Personal.Common;

/// <summary>
/// Maneja la generación de los numeros de control para personal
/// </summary>
public class GeneradorNumeroControl : IGeneradorNumeroControl 
{
  public static readonly Random _random = new();


  public string GenerarNumeroControl(string prefijo) {
    var sections = new List<string>();


    for (int i = 0; i < 4; i++)
    {
        sections.Add(RandomAlfaNumerico(3));
    }
    
    return prefijo + "-" + string.Join("-", sections);
  }

  public string RandomAlfaNumerico(int length)
  {
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string([.. Enumerable.Range(0, length).Select(_ => chars[_random.Next(chars.Length)])]);
  }
}