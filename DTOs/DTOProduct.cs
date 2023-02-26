namespace DTOs;

using System.ComponentModel.DataAnnotations;
using Models;

public class DTOProduct:DTOCommon
{
    [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
    public string? Title { get; set; }
    [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
    public double Cost { get; set; }
    [StringLength(25, ErrorMessage = "Must be between 10 and 25 characters", MinimumLength = 10)]
    public string? Description { get; set; }
    [DataType(DataType.Url)]
    public string[] Images { get; set; } = new string[3];

    public override void UpdateModel(Product p)
    {
        p.Images =Images;
        p.Cost = Cost;
        p.Description = Description;
        p.Title = Title;
    }
}