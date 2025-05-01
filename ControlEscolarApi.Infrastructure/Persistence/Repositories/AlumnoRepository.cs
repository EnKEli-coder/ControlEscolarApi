using System.Linq.Expressions;
using System.Threading.Tasks;
using Azure.Core;
using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlEscolarApi.Infrastructure.Persistence.Repositories;

public class AlumnoRepository(ControlEscolarDbContext dbContext) : IGenericRepository<Alumno>
{
  private readonly ControlEscolarDbContext _dbContext = dbContext;

  public void Add(Alumno model)
  {
    _dbContext.Add(model);
  }

  public IQueryable<Alumno> GetAll(PaginationQueryParams queryParams)
  {

    IQueryable<Alumno> query = _dbContext.Alumnos;

    if(!string.IsNullOrWhiteSpace(queryParams.Search)) {
      query = query.Where(alumno => alumno.NumeroControl.Contains(queryParams.Search));
    }

    return query;
  }

  public async Task<List<Alumno>> GetAllAsync()
  {
    return await _dbContext.Alumnos.ToListAsync();
  }

  public Alumno? GetById(int id)
  {
    return _dbContext.Alumnos.Find(id);
  }

  public async Task<Alumno?> GetByIdAsync(int id)
  {
    return await _dbContext.Alumnos.FindAsync(id);
  }

  public Alumno? GetByIdWithIncludes(int id)
  {
    return _dbContext.Alumnos.Find(id);
  }

  public async Task<Alumno?> GetByIdWithIncludesASync(int id)
  {
    return await _dbContext.Alumnos.FindAsync(id);
  }

    public IEnumerable<Alumno> GetList(Expression<Func<Alumno, bool>> predicate)
    {
        return _dbContext.Alumnos.Where(predicate).ToList();
    }

    public async Task<List<Alumno>> GetListAsync(Expression<Func<Alumno, bool>> predicate)
    {
        return await _dbContext.Alumnos.Where(predicate).ToListAsync();
    }

    public bool Remove(int id)
  {
    var model = _dbContext.Alumnos.Find(id);
        if (model is { })
        {
            _dbContext.Alumnos.Remove(model);
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

  public Alumno? Select(Expression<Func<Alumno, bool>> predicate)
  {
    return _dbContext.Alumnos.FirstOrDefault(predicate);
  }

  public async Task<Alumno?> SelectAsync(Expression<Func<Alumno, bool>> predicate)
  {
    return await _dbContext.Alumnos.FirstOrDefaultAsync(predicate);
  }

  public void Update(Alumno model)
  {
    _dbContext.Entry(model).State = EntityState.Modified;
  }
}