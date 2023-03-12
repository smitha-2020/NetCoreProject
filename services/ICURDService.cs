namespace project.services;
using project.Models;
using project.DTOs;

public interface ICURDService<TModel, TDto> 
where TModel : BaseModel, new() 
where TDto:BaseDTO<TModel>
{
  // CURD Operations
  Task<TModel?> CreateAsync(TDto request);
  Task<TModel?> GetAsync(int id);
  Task<TModel?> UpdateAsync(int id, TDto request);
  Task<bool> DeleteAsync(int id);
  Task<ICollection<TModel>> GetAllAsync();
}