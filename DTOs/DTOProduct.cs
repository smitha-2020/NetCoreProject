namespace DTOs;

using System.ComponentModel.DataAnnotations;
using Models;

public class DTOProduct : DTOCommon
{

  public string? Title { get; set; }

  public double Cost { get; set; }

  public string? Description { get; set; }

  public string Images { get; set; }

  public int CategoryID { get; set; }

  public override void UpdateModel(Product p)
  {
    p.Images = Images;
    p.Cost = Cost;
    p.Description = Description;
    p.Title = Title;
    p.CategoryID = CategoryID;
  }
}