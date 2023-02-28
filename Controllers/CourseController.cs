namespace project.Controller;

using Microsoft.AspNetCore.Mvc;
using project.Controllers;
using project.services;
using project.Models;
using project.DTOs;

public class CourseController : FakeController<Course, CourseDTO>
{
  private readonly ICourseService _service;
  //private readonly ICURDServiceCOPY<Course, CourseDTO> _service;
  public CourseController(ICourseService service) : base(service)
  {
    _service = service;
  }

  [HttpGet("ongoing")]
  public async Task<ActionResult<ICollection<Course>>> GetOngoingCouses([FromQuery] Course.CourseStatus status)
  {
    return Ok(await _service.GetCourseByStatus(status));
  }

  // [HttpGet("{status}")]
  // public ActionResult<ICollection<Course>> GetCoursesByStatus([FromQuery]Course.CourseStatus status)
  // {
  //   return Ok(_service.GetCourseByStatus(status));
  // }

  // [HttpGet("{id}")]
  // public ActionResult<Course?> Get(int id)
  // {
  //   if (_service.Get(id) is null)
  //   {
  //     return NotFound("Course is not found");
  //   }
  //   return _service.Get(id);
  // }

  // [HttpPut("{id}")]
  // public ActionResult Update(int id, CourseDTO course)
  // {
  //   _logger.LogInformation("Update Action");
  //   var c = _service.Update(id, course);
  //   if (c is null)
  //   {
  //     return NotFound("Course is not found");
  //   }
  //   return Ok(c);
  // }

  // [HttpDelete("{id:int}")]
  // public ActionResult Delete(int id)
  // {
  //   if (_service.Delete(id))
  //   {
  //     return Ok("Course Deleted successfully");
  //   }
  //   return NotFound("Course could not be deleted");
  // }

  // [HttpGet]
  // public ICollection<Course> GetAll()
  // {
  //   return _service.GetAll();
  // }

}