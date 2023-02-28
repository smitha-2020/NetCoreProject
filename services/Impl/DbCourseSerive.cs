using Microsoft.EntityFrameworkCore;
using project.DB;
using project.DTOs;
using project.Models;
using System.Collections.Concurrent;

namespace project.services.Impl;

public class DbCourseSerive : DbCrudService<Course, CourseDTO>, ICourseService
{
  private ConcurrentDictionary<int, Course> _courseDict = new();
  private int _courseId;
  //Needs to be
  private readonly AppDBContext _dbContext;

  public DbCourseSerive(AppDBContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<ICollection<Course>> GetCourseByStatus(Course.CourseStatus status)
  {
    return await _dbContext.Courses.Where(item => item.Status == status).ToListAsync();
  }


}