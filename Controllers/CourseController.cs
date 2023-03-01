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
}