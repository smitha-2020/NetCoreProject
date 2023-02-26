namespace project.services;
using project.Models;
using project.DTOs;

public interface ICURDServiceCOPY<TModel, TDto> where TModel : BaseModel, new() where TDto:BaseDTO<TModel>
{
  // CURD Operations
  TModel? Create(TDto request);
  TModel? Get(int id);
  TModel? Update(int id, TDto request);
  bool Delete(int id);
  ICollection<TModel> GetAll();
}