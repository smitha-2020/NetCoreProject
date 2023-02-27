namespace Models;

public class Product : BaseEntity
{
    public string? Title { get; set; }
    public double Cost { get; set; }    
    public string? Description { get; set; }
    public string Images { get; set; }
    public int CategoryID { get; set; }
}