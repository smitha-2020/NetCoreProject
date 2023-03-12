namespace project.DTOs;

using project.Models;
using System.ComponentModel.DataAnnotations;

public class DTOCategory : BaseDTO<Category>
{
  [StringLength(50, MinimumLength = 9)]
  public string Name { get; set; } = String.Empty;
  
  public string Image { get; set; } = null!;

  //public ICollection<Product> Products {get; set;} = null!;

  public override void UpdateModel(Category model)
  {
    model.Name = Name;
    model.Image = Image;
  }
}