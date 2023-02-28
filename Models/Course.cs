namespace project.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Course : BaseModel
{
  public string Name { get; set; } = null!;
  public DateTime StartDate { get; set; }
  //public DateTime EndDate { get; set; }
  public CourseStatus Status { get; set; }
  //using data annotattion
  [Column("size", TypeName = "smallint")]
  public int Size { get; set; }

  public enum CourseStatus
  {
    NotStarted,
    OnGoing,
    Ended
  }
}