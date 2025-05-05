namespace ControlEscolarApi.Contracts.Common;


/// <summary>
/// Representa una respuesta con datos de paginación
/// </summary>
public class PaginatedListResponse<T>
{
    public List<T> Items { get; set;} = new();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }    
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage {get; set;}
    
}