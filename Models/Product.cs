using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models;

public class Product : BaseModel
{
    public string? Title { get; set; }
    public double Cost { get; set; }    
    public string? Description { get; set; }

    [Column(TypeName = "jsonb")]
    public ICollection<string> Images { get; set; } = null!;
    
    public int CategoryID { get; set; }
}