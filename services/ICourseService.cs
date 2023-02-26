namespace project.services;
using project.Models;
using project.DTOs;

public interface ICourseService
{
  // CURD Operations
    Course? Create(CourseDTO request);
    Course? Get(int id);
    Course? Update(int id,CourseDTO request);
    bool Delete(int id);
    ICollection<Course> GetAll();

}