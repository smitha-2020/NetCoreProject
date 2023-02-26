namespace project.Controller;

using Microsoft.AspNetCore.Mvc;
using project.Controllers;
using project.services;
using project.Models;
using project.DTOs;

public class StudentController : ApiController
{
  private readonly ILogger<StudentController> _logger;
  private readonly IStudentService _studentService;
  public StudentController(ILogger<StudentController> logger, IStudentService studentService)
  {
    _logger = logger ?? throw new ArgumentException(nameof(logger));
    _studentService = studentService ?? throw new ArgumentException(nameof(studentService));
  }

  [HttpPost]
  public IActionResult Create(StudentDTO student)
  {
    //_logger.LogInformation("Creating New Student");
    _studentService.Create(student);
    return Ok();
  }

  [HttpGet("{id}")]
  public ActionResult<Student?> Get(int id)
  {
    if (_studentService.Get(id) is null)
    {
      return NotFound("student is not found");
    }
    return _studentService.Get(id);
  }

  [HttpPut("{id}")]
  public ActionResult Update(int id, StudentDTO student)
  {
    _logger.LogInformation("Update Action");
    var c = _studentService.Update(id, student);
    if (c is null)
    {
      return NotFound("student is not found");
    }
    return Ok(c);
  }

  [HttpDelete("{id:int}")]
  public ActionResult Delete(int id)
  {
    if (_studentService.Delete(id))
    {
      return Ok("student Deleted successfully");
    }
    return NotFound("student could not be deleted");
  }

  [HttpGet]
  public ICollection<Student> GetAll(int id)
  {
    return _studentService.GetAll();
  }

}