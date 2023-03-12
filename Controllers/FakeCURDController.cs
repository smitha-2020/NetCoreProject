// namespace project.Controllers;

// using Microsoft.AspNetCore.Mvc;
// using Services.Interface;
// using  project.DTOs;
// using  project.Models;

// public class FakeCURDController : ApiController
// {
//   private readonly ILogger<FakeCURDService> _logger;
//   private readonly ICURDService _service = null;

//   public FakeCURDController(ICURDService service, ILogger<FakeCURDService> logger)
//   {
//     _service = service;
//     _logger = logger;
//   }

//   [HttpPost]
//   public ActionResult<Product> Create(DTOProduct product)
//   {
//     _logger.LogInformation("Create action..");
//     var data = _service.Create(product);
//     if (data is null)
//     {
//       return NotFound("Coould not be created!!!");
//     }
//     return Ok(data);
//   }

//   [HttpGet]
//   public ActionResult<ICollection<Product>> GetAll()
//   {
//     _logger.LogInformation("Fetching all data..");
//     if (_service.GetAll() is null)
//     {
//       return NotFound("No data to be returned");
//     }
//     return Ok(_service.GetAll());
//   }

//   [HttpPut("{id:int}")]
//   public ActionResult<Product> Update(int id, DTOProduct product)
//   {
//     _logger.LogInformation("Create action..");
//     var data = _service.Update(id, product);
//     if (data is null)
//     {
//       return NotFound("Coould not be Updated!!!");
//     }
//     return Ok(data);
//   }

//   [HttpDelete("{id}")]
//   public ActionResult Delete(int id)
//   {
//     _logger.LogInformation("Create action..");
//     var data = _service.Delete(id);
//     if (!data)
//     {
//       return NotFound(new {Message = "Could not be Deleted!!!"});
//     }
//     return Ok(new {Message = "Data deleted successfully"});
//   }
// }