using System.Linq.Expressions;
using ControlEscolarApi.Application.Common.QueryParams;

namespace ControlEscolarApi.Application.Interfaces.Persistence;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll(PaginationQueryParams queryParams);
    Task<List<T>> GetAllAsync();
    T? GetById(int id);
    T? GetByIdWithIncludes(int id);
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByIdWithIncludesASync(int id);
    IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);
    void Add(T model);
    void Update (T model);
    bool Remove(int id);
    int Save();
    Task<int> SaveAsync();
    public T? Select(Expression<Func<T, bool>> predicate);
    public Task<T?> SelectAsync(Expression<Func<T, bool>> predicate);
}
