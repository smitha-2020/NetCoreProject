namespace project.Controller;

using Microsoft.AspNetCore.Mvc;
using project.Controllers;
using project.services;
using project.Models;
using project.DTOs;

public class CourseController : ApiController
{
  private readonly ILogger<CourseController> _logger;
  private readonly ICURDServiceCOPY<Course,CourseDTO> _service;
  public CourseController(ILogger<CourseController> logger, ICURDServiceCOPY<Course,CourseDTO> service)
  {
    _logger = logger ?? throw new ArgumentException(nameof(logger));
    _service = service ?? throw new ArgumentException(nameof(logger));
  }

  [HttpPost]
  public IActionResult Create(CourseDTO course)
  {
    _logger.LogInformation("Creating new Courses..");
    _service.Create(course);
    return Ok();
  }

  [HttpGet("{id}")]
  public ActionResult<Course?> Get(int id)
  {
    if (_service.Get(id) is null)
    {
      return NotFound("Course is not found");
    }
    return _service.Get(id);
  }

  [HttpPut("{id}")]
  public ActionResult Update(int id, CourseDTO course)
  {
    _logger.LogInformation("Update Action");
    var c = _service.Update(id, course);
    if (c is null)
    {
      return NotFound("Course is not found");
    }
    return Ok(c);
  }

  [HttpDelete("{id:int}")]
  public ActionResult Delete(int id)
  {
    if (_service.Delete(id))
    {
      return Ok("Course Deleted successfully");
    }
    return NotFound("Course could not be deleted");
  }

  [HttpGet]
  public ICollection<Course> GetAll()
  {
    return _service.GetAll();
  }

}