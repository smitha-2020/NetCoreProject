using project.DTOs;
using project.Models;
using System.Collections.Concurrent;

namespace project.services.Impl;

public class FakeStudentService : IStudentService
{
  private ConcurrentDictionary<int, Student> _studentDict = new();
  private int _studentId;

  public Student? Create(StudentDTO request)
  {
    var student = new Student
    {
      Id = Interlocked.Increment(ref _studentId),
      FirstName = request.FirstName,
      LastName = request.LastName,
      Email = request.Email
    };
    _studentDict[student.Id] = student;
    return student;
  }

  public bool Delete(int id)
  {
    if (!_studentDict.ContainsKey(id))
    {
      return false;
    }
    _studentDict.TryRemove(id, out var result);
    return true;
  }

  public Student? Get(int id)
  {
    if (_studentDict.TryGetValue(id, out var result))
    {
      return result;
    }
    return null;
  }

  public ICollection<Student> GetAll()
  {
    return _studentDict.Values;
  }

  public Student? Update(int id, StudentDTO request)
  {
    var student = Get(id);
    if (student is null)
    {
      return null;
    }
    student.FirstName = request.FirstName;
    student.LastName = request.LastName;
    student.Email = request.Email;
    return student;
  }
}