namespace project.services;

using project.Models;
using project.DTOs;

public interface ICategoryService:ICURDServiceCOPY<Category,DTOCategory>
{
  Task<ICollection<Category>> GetByNameOrder();
}