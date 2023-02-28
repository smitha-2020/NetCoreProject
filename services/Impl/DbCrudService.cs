namespace project.services.Impl;

using System.Collections.Generic;
using System.Threading.Tasks;
using project.DB;
using project.DTOs;
using project.Models;


public class DbCrudService<TModel, TDto> : ICURDServiceCOPY<TModel, TDto>
where TModel : BaseModel, new()
where TDto : BaseDTO<TModel>
{
  private readonly AppDBContext _dbContext;
  public DbCrudService(AppDBContext dbContext)
  {
    _dbContext = dbContext;
  }
  public async Task<TModel?> Create(TDto request)
  {
    var item = new TModel();
    request.UpdateModel(item);
    _dbContext.Add(item);
    await _dbContext.SaveChangesAsync();
    return item;
  }

  public async Task<bool> Delete(int id)
  {
    var item = await Get(id);
    if (item is null)
    {
      return false;
    }
    _dbContext.Remove(id);
    await _dbContext.SaveChangesAsync();
    return true;
  }

  public async Task<TModel?> Get(int id)
  {
    return await _dbContext.Set<TModel>().FindAsync(id);
  }

  public virtual async Task<ICollection<TModel>> GetAll()
  {
    return _dbContext.Set<TModel>().ToList();
  }

  public async Task<TModel?> Update(int id, TDto request)
  {
    var item = await Get(id);
    if (item is null)
    {
      return null;
    }
    request.UpdateModel(item);
    await _dbContext.SaveChangesAsync();
    return item;
  }
}