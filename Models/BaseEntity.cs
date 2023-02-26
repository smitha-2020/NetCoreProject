namespace Models;

using System;

public abstract class BaseEntity
{
    private DateTime creationAt { get; set; } = DateTime.Now;
    public DateTime updatedAt { get; set; } = DateTime.Now;
    public int Id { get; set; }
}