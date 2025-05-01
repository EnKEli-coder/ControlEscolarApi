using System.Linq.Expressions;
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

  public IEnumerable<Personal> GetAll()
  {
    return _dbContext.Personal.ToList();
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