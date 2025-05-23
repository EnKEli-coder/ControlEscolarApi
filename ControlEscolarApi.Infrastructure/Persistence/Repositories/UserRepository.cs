using System.Data.Common;
using System.Linq.Expressions;
using ControlEscolarApi.Application.Authentication.Common;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Infrastructure.Persistence.Repositories;

public class UserRepository(ControlEscolarDbContext dbContext) : IGenericRepository<User>
{
  private readonly ControlEscolarDbContext _dbContext = dbContext;

  public void Add(User model)
  {
    throw new NotImplementedException();
  }

  public IQueryable<User> GetAll(PaginationQueryParams queryParams)
  {
    throw new NotImplementedException();
  }

  public Task<List<User>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public User? GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetByIdAsync(int id)
  {
    throw new NotImplementedException();
  }

  public User? GetByIdWithIncludes(int id)
  {
    throw new NotImplementedException();
  }

  public Task<User?> GetByIdWithIncludesASync(int id)
  {
    throw new NotImplementedException();
  }

    public IEnumerable<User> GetList(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetListAsync(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public bool Remove(int id)
  {
    throw new NotImplementedException();
  }

  public int Save()
  {
    throw new NotImplementedException();
  }

  public Task<int> SaveAsync()
  {
    throw new NotImplementedException();
  }

  public User? Select(Expression<Func<User, bool>> predicate)
  {
    throw new NotImplementedException();
  }

  public async Task<User?> SelectAsync(Expression<Func<User, bool>> predicate)
  {
    return await _dbContext.Users.FirstOrDefaultAsync(predicate);
  }

  public void Update(User model)
  {
    throw new NotImplementedException();
  }

  public async Task ExecuteStoredProcedureAsync(string spName, params DbParameter[] parameters)
  {
#pragma warning disable EF1002 
    await _dbContext.Database.ExecuteSqlRawAsync(
        $"EXEC {spName} {string.Join(",", parameters.Select(p => $"@{p.ParameterName}"))}",
        parameters);
#pragma warning restore EF1002 
  }
}