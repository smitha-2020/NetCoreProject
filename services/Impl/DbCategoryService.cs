using Microsoft.EntityFrameworkCore;
using project.DB;
using project.DTOs;
using project.Models;
using project.services.Impl;

namespace project.services.Impl;

public class DbCategoryService : DbCrudService<Category, DTOCategory>, ICategoryService
{
    private readonly AppDBContext _dbContext;
    public DbCategoryService(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    // public async Task<int> AddProductToCategory(int id, ICollection<int> productIds)
    // {
    //     var category = await GetAsync(id);
    //     if (category is null)
    //     {
    //         return -1;
    //     }
    //     var validProducts = _dbContext.Products.Where(x => productIds.Contains(x.Id)).ToList();
    //     foreach (var selectedProduct in validProducts)
    //     {
    //         if (!category.Products.Contains(selectedProduct))
    //         {
    //             category.Products.Add(selectedProduct);
    //         }
    //         return -1;
    //     }
    //     await _dbContext.SaveChangesAsync();
    //     return await Task.Run(() => validProducts.Count());
    // }

    public async Task<ICollection<Category>> GetByNameOrder()
    {
        return await Task.Run(() => _dbContext.Categorys.OrderBy(x => x.Id).ToList());
    }
}