using System.Linq.Expressions;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Infrastructure.Persistence.Repositories;

public class TipoPersonalRepository(ControlEscolarDbContext dbContext)  : IGenericRepository<TipoPersonal>
{
  private readonly ControlEscolarDbContext _dbContext = dbContext;

  public void Add(TipoPersonal model)
  {
    _dbContext.Add(model);
  }

  public IEnumerable<TipoPersonal> GetAll()
  {
    return _dbContext.TiposPersonal.ToList();
  }

  public async Task<List<TipoPersonal>> GetAllAsync()
  {
    return await _dbContext.TiposPersonal.ToListAsync();
  }

  public TipoPersonal? GetById(int id)
  {
    return _dbContext.TiposPersonal.Find(id);
  }

  public async Task<TipoPersonal?> GetByIdAsync(int id)
  {
    return await _dbContext.TiposPersonal.FindAsync(id);
  }

  public TipoPersonal? GetByIdWithIncludes(int id)
  {
    return _dbContext.TiposPersonal.Find(id);
  }

  public async Task<TipoPersonal?> GetByIdWithIncludesASync(int id)
  {
    return await _dbContext.TiposPersonal.FindAsync(id);
  }

  public bool Remove(int id)
  {
    var model = _dbContext.TiposPersonal.Find(id);
      if (model is { })
      {
          _dbContext.TiposPersonal.Remove(model);
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

  public TipoPersonal? Select(Expression<Func<TipoPersonal, bool>> predicate)
  {
    return _dbContext.TiposPersonal.FirstOrDefault(predicate);
  }

  public async Task<TipoPersonal?> SelectAsync(Expression<Func<TipoPersonal, bool>> predicate)
  {
    return await _dbContext.TiposPersonal.FirstOrDefaultAsync(predicate);
  }

  public void Update(TipoPersonal model)
  {
    _dbContext.Entry(model).State = EntityState.Modified;
  }
}