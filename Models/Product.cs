namespace Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Product : BaseEntity
{
    public string? Title { get; set; }
    public double Cost { get; set; }    
    public string? Description { get; set; }
    public string[] Images { get; set; } = new string[3];
    public int CategoryID { get; set; }
}