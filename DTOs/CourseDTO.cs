namespace project.DTOs;

using System.ComponentModel.DataAnnotations;
using project.Models;
using project.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations.Schema;

public class CourseDTO : BaseDTO<Course>, IValidatableObject
{
  [MinLength(5, ErrorMessage = "Name should be atleast 5 charecters long.")]
  public string Name { get; set; }

  [CourseStartDate]
  public DateTime StartDate { get; set; }

  //public DateTime EndDate { get; set; }
  public Course.CourseStatus Status { get; set; }

  public override void UpdateModel(Course model)
  {
    Console.WriteLine("Course Constuctor..");
    model.Name = Name;
    model.StartDate = StartDate;
    model.Status = Status;
  }

  //Attribute
  [Column("course_size",TypeName="smallint")]
  public int Size { get; set; }

  public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
  {
    if (StartDate < DateTime.Now && Status == Course.CourseStatus.NotStarted)
    {
      yield return new ValidationResult("Status or StartDate is not Appropriate", new string[] { nameof(StartDate), nameof(Status) });
    }
  }
}