using project.DTOs;
using project.Models;
using System.Collections.Concurrent;

namespace project.services.Impl;

public class FakeCourseSeriveCOPY : ICourseService
{
  private ConcurrentDictionary<int, Course> _courseDict = new();
  private int _courseId;
  public async Task<Course?> Create(CourseDTO request)
  {
    var course = new Course
    {
      Id = Interlocked.Increment(ref _courseId),
      Name = request.Name,
      StartDate = request.StartDate,
      Status = request.Status
    };

    _courseDict[course.Id] = course;
    return await Task.Run(()=> course);
  }

  public async Task<bool> Delete(int id)
  {
    if (!_courseDict.ContainsKey(id))
    {
      return false;
    }
    _courseDict.TryRemove(id, out var result);
    return await Task.Run(()=> true);
  }

  public async Task<Course?> Get(int id)
  {
    if (_courseDict.TryGetValue(id, out var result))
    {
      return await Task.Run(()=> result);
    }
    return null;
  }

  public async Task<ICollection<Course>> GetAll()
  {
    return await Task.Run(()=> _courseDict.Values);
  }

  public async Task<ICollection<Course>> GetCourseByStatus(Course.CourseStatus status)
  {
    return await Task.Run(() => _courseDict.Values.Where(item => item.Status == status).ToList());
  }

  public async Task<Course?> Update(int id, CourseDTO request)
  {
    var course = await Get(id);
    if (course is null)
    {
      return null;
    }
    course.Name = request.Name;
    course.Status = request.Status;
    course.StartDate = request.StartDate;
    return await Task.Run(()=> course);
  }
}