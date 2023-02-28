namespace project.DTOs;

using project.Models;
using project.DTOs;

public class DTOCategory : BaseDTO<Category>
{
  public string Name { get; set; } = String.Empty;
  public string Image { get; set; } = null!;

  public override void UpdateModel(Category model)
  {
    model.Name = Name;
    model.Image = Image;
  }
}