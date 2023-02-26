namespace project.Models;

public abstract class BaseModel
{
    public int Id { get; set; }
    public DateTime creationAt {get;} = DateTime.Now; 
    public DateTime updatedAt {get; set;} = DateTime.Now; 

}