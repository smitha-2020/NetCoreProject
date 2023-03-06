namespace project.DTOs;

using System.ComponentModel.DataAnnotations;
using project.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class DTOProduct : BaseDTO<Product>
{
    [MaxLength(20, ErrorMessage = "maximum {1} characters allowed")]
    public string? Title { get; set; }

    public double Cost { get; set; }

    [MinLength(10, ErrorMessage = "minimum {1} characters should be provided")]
    public string? Description { get; set; }

    public ICollection<string> Images { get; set; } = null!;

    //public int CategoryID { get; set; }

    public override void UpdateModel(Product p)
    {
        p.Images = Images;
        p.Cost = Cost;
        p.Description = Description;
        p.Title = Title;
        //p.CategoryID = CategoryID;
    }
}