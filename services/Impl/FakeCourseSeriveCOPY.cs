using project.DTOs;
using project.Models;
using System.Collections.Concurrent;

namespace project.services.Impl;

public class FakeCourseSeriveCOPY : ICourseService
{
  private ConcurrentDictionary<int, Course> _courseDict = new();
  private int _courseId;
  public Course? Create(CourseDTO request)
  {
    var course = new Course
    {
      Id = Interlocked.Increment(ref _courseId),
      Name = request.Name,
      StartDate = request.StartDate,
      Status = request.Status
    };

    _courseDict[course.Id] = course;
    return course;
  }

  public bool Delete(int id)
  {
    if (!_courseDict.ContainsKey(id))
    {
      return false;
    }
    _courseDict.TryRemove(id, out var result);
    return true;
  }

  public Course? Get(int id)
  {
    if (_courseDict.TryGetValue(id, out var result))
    {
      return result;
    }
    return null;
  }

  public ICollection<Course> GetAll()
  {
    return _courseDict.Values;
  }

  public Course? Update(int id, CourseDTO request)
  {
    var course = Get(id);
    if (course is null)
    {
      return null;
    }
    course.Name = request.Name;
    course.Status = request.Status;
    course.StartDate = request.StartDate;
    return course;
  }
}