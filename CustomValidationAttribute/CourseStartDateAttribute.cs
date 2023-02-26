using System.ComponentModel.DataAnnotations;

namespace project.CustomValidationAttribute;
using project.Models;

public class CourseStartDateAttribute : ValidationAttribute
{
  public override bool IsValid(object? value){
    if(value is null){
      return false;
    }
    var startDate = (DateTime)value;
    return startDate.Year == DateTime.Now.Year; 
  }
}