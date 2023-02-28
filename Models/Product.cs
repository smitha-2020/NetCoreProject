namespace project.Models;

public class Product : BaseModel
{
    public string? Title { get; set; }
    public double Cost { get; set; }    
    public string? Description { get; set; }
    public string Images { get; set; }
    public int CategoryID { get; set; }
}