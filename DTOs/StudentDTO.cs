using System.ComponentModel.DataAnnotations;
using project.Models;

namespace project.DTOs;

public class StudentDTO : BaseDTO<Student>
{
  [MinLength(3, ErrorMessage = "FirstName must be atleast 5 letters.")]
  public string FirstName { get; set; }

  [MinLength(3, ErrorMessage = "FirstName must be atleast 5 letters.")]
  public string LastName { get; set; }

  [EmailAddress]
  public string Email { get; set; }

  public override void UpdateModel(Student model)
  {
    model.FirstName = FirstName;
    model.LastName = LastName;
    model.Email = Email;
  }
}