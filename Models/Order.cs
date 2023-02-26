namespace project.Models;

public class Order
{
  public int CustomerId { get; set; }
  public ICollection<OrderItem> Items { get; set; }
}

public class OrderItem
{
  public int ProductId { get; set; }
  public int Quantity { get; set; }
}