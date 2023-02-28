namespace project.services;
using project.Models;
using project.DTOs;

public interface IProductService : ICURDServiceCOPY<Product, DTOProduct>
{
  // CURD Operations + Any new Operations
  Task<ICollection<Product>> GetAllProductsByCostAsc();
}