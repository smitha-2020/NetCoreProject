namespace project.Controller;

using Microsoft.AspNetCore.Mvc;
using project.Controllers;
using project.services;
using project.Models;
using project.DTOs;

public class StudentController : FakeController<Student, StudentDTO>
{
  private readonly ICURDServiceCOPY<Student, StudentDTO> _studentService;
  public StudentController(ICURDServiceCOPY<Student, StudentDTO> studentService) : base(studentService)
  {
    _studentService = studentService ?? throw new ArgumentException(nameof(studentService));
  }
}