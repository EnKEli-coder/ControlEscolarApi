using System.Linq.Expressions;

namespace ControlEscolarApi.Application.Interfaces.Persistence;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    Task<List<T>> GetAllAsync();
    T? GetById(int id);
    T? GetByIdWithIncludes(int id);
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByIdWithIncludesASync(int id);
    void Add(T model);
    void Update (T model);
    bool Remove(int id);
    int Save();
    Task<int> SaveAsync();
    public T? Select(Expression<Func<T, bool>> predicate);
    public Task<T?> SelectAsync(Expression<Func<T, bool>> predicate);
}
