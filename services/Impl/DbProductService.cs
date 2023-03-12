using Microsoft.EntityFrameworkCore;
using project.DB;
using project.DTOs;
using project.Models;
using project.AutoMapper;
using project.services.Impl;

namespace project.services.Impl;

public class DbProductService : DbCrudService<Product, DTOProduct>, IProductService
{
  private readonly AppDBContext _dbContext;
  public DbProductService(AppDBContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }

  public override async Task<Product?> GetAsync(int id)
  {
    //return await Task.Run(() =>  _dbContext.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id));
    var selectedData = await Task.Run(() => GetAllAsync().Result.SingleOrDefault(x => x.Id == id));
    return selectedData;
  }
  
  public async Task<ICollection<Product>> GetAllProductsByCostAsc()
  {
    return await Task.Run(() => _dbContext.Products.AsNoTracking().Include(x => x.Category).OrderBy(x => x.Price).ToList());
  }

}