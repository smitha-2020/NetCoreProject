namespace project.services;

using project.Models;

public interface IOrderProcessingService
{
  bool ProcessOrder(Order o);
}