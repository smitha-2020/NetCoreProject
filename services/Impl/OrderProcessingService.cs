using project.Models;

namespace project.services.Impl;

public class OrderProcessingService : IOrderProcessingService
{
  private readonly ILogger<OrderProcessingService> _logger;
  private readonly IEmailSenderService _emailService;

  public OrderProcessingService(ILogger<OrderProcessingService> logger, IEmailSenderService emailService)
  {
    _logger = logger;
    _emailService = emailService;
  }
  public bool ProcessOrder(Order o)
  {
    if (HandleOrder(o))
    {
      _emailService.SendEmail("customer@mai.com", "your order is processed", "Success");
    }
    else
    {
      _emailService.SendEmail("customer@mai.com", "failed to process order", "Failed");
    }
    return true;
  }
  public bool HandleOrder(Order order)
  {
    return true;
  }
}