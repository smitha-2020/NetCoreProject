namespace project.services;
using project.Models;
using project.DTOs;

public interface IStudentService
{
  // CURD Operations
  Student? Create(StudentDTO request);
  Student? Get(int id);
  Student? Update(int id, StudentDTO request);
  bool Delete(int id);
  ICollection<Student> GetAll();

}