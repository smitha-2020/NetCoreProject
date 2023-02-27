namespace project.services;
using project.Models;
using project.DTOs;

public interface ICourseService : ICURDServiceCOPY<Course, CourseDTO>
{
  ICollection<Course> GetCourseByStatus(Course.CourseStatus status);
}