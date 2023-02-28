namespace project.Services.Interface;
using project.Models;
using project.DTOs;

public interface ICURDService
{
  Product Create(DTOProduct newData);
  Product Update(int id, DTOProduct updateData);
  bool Delete(int id);
  Product Get(int id);
  ICollection<Product> GetAll();
}
