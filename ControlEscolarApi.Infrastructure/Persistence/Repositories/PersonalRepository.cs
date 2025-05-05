using System.Linq.Expressions;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Infrastructure.Persistence.Repositories;

public class PersonalRepository(ControlEscolarDbContext dbContext) : IGenericRepository<Personal>
{
  private readonly ControlEscolarDbContext _dbContext = dbContext;
  
  public void Add(Personal model)
  {
    _dbContext.Add(model);
  }

  public IQueryable<Personal> GetAll(PaginationQueryParams queryParams)
  {
    IQueryable<Personal> query = _dbContext.Personal;

    if(!string.IsNullOrWhiteSpace(queryParams.Search)) {

      var search = queryParams.Search.Replace("-", "", StringComparison.Ordinal).ToLowerInvariant();

      query = query.Where(a => EF.Functions.Like(
            a.NumeroControl.Replace("-", "").ToLower(),
            $"%{search}%"));
    }

    query = query.OrderByDescending(personal => personal.FechaCreacion);

    return query;
  }

  public async Task<List<Personal>> GetAllAsync()
  {
    return await _dbContext.Personal.ToListAsync();
  }

  public Personal? GetById(int id)
  {
    return _dbContext.Personal.Find(id);
  }

  public async Task<Personal?> GetByIdAsync(int id)
  {
    return await _dbContext.Personal.FindAsync(id);
  }

  public Personal? GetByIdWithIncludes(int id)
  {
    return _dbContext.Personal.Find(id);
  }

  public async Task<Personal?> GetByIdWithIncludesASync(int id)
  {
    return await _dbContext.Personal.FindAsync(id);
  }

    public IEnumerable<Personal> GetList(Expression<Func<Personal, bool>> predicate)
    {
       return _dbContext.Personal.Where(predicate).ToList();
    }

    public async Task<List<Personal>> GetListAsync(Expression<Func<Personal, bool>> predicate)
    {
       return await _dbContext.Personal.Where(predicate).ToListAsync();
    }

    public bool Remove(int id)
  {
    var model = _dbContext.Personal.Find(id);
      if (model is { })
      {
          _dbContext.Personal.Remove(model);
          return true;
      }

      return false;
  }

  public int Save()
  {
    return _dbContext.SaveChanges();
  }

  public Task<int> SaveAsync()
  {
    return _dbContext.SaveChangesAsync();
  }

  public Personal? Select(Expression<Func<Personal, bool>> predicate)
  {
    return _dbContext.Personal.FirstOrDefault(predicate);
  }

  public async Task<Personal?> SelectAsync(Expression<Func<Personal, bool>> predicate)
  {
    return await _dbContext.Personal.FirstOrDefaultAsync(predicate);
  }

  public void Update(Personal model)
  {
    _dbContext.Entry(model).State = EntityState.Modified;
  }
}