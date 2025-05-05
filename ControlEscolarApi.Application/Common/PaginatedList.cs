using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Application.Common;

public class PaginatedList<T>(
    List<T> items,
    int page,
    int pageSize,
    int totalCount
)
{
    public IEnumerable<T> Items { get; set;} = items;
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
    public int TotalCount { get; set; } = totalCount;

    public bool HasNextPage => Page * PageSize < TotalCount;

    public bool HasPreviousPage => Page > 1;
    
    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize) {
        var totalCount = await query.CountAsync();

        if(pageSize > totalCount) {
            page = 1;
        }

        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return new(items, page, pageSize, totalCount);
    }
    
}