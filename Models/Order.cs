namespace project.Models;

public class Order
{
  public int CustomerId { get; set; }
  public ICollection<OrderItem> Items { get; set; } = null!;
}

public class OrderItem
{
  public int ProductId { get; set; }
  public int Quantity { get; set; }
}