// namespace project.Controllers;

// using project.services;
// using project.Models;
// using Microsoft.AspNetCore.Mvc;

// public class OrderController : ApiController
// {
//   private readonly ILogger<OrderController> _logger;
//   private readonly IOrderProcessingService _service;
//   private readonly ICounterService _counterService;

//   public OrderController(ILogger<OrderController> logger, IOrderProcessingService service,ICounterService counterService)
//   {
//     _logger = logger;
//     _service = service;
//     _counterService = counterService;
//     _logger.LogInformation($"In {nameof(OrderController)} controller..");
//   }

//   [HttpGet]
//   public ActionResult display()
//   {
//     _counterService.Increase();
//     return Ok(new {CurrentCounter = _counterService.CounterValue});
//   }

//   [HttpPost]
//   public ActionResult MakeOrder(Order o)
//   {
//     if (!_service.ProcessOrder(o))
//     {
//       _logger.LogError($"Failed to process the order {o.CustomerId}");
//     }
//     return Ok(new { Message = "Succesfuly Processed" });
//   }
// }