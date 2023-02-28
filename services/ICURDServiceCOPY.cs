namespace project.services;
using project.Models;
using project.DTOs;

public interface ICURDServiceCOPY<TModel, TDto> where TModel : BaseModel, new() where TDto:BaseDTO<TModel>
{
  // CURD Operations
  Task<TModel?> Create(TDto request);
  Task<TModel?> Get(int id);
  Task<TModel?> Update(int id, TDto request);
  Task<bool> Delete(int id);
  Task<ICollection<TModel>> GetAll();
}