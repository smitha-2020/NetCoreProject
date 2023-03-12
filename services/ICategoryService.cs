namespace project.services;

using project.Models;
using project.DTOs;

public interface ICategoryService : ICURDService<Category, DTOCategory>
{
    Task<ICollection<Category>> GetByNameOrder();
    //Task<int> AddProductToCategory(int id, ICollection<int> productIds);
}