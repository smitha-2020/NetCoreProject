// namespace project.Controllers;

// using Microsoft.AspNetCore.Mvc;

// using project.services;
// using project.Models;
// using project.DTOs;

// public abstract class FakeController<TModel, TDto> : ApiController
// where TModel : BaseModel, new()
// where TDto : BaseDTO<TModel>
// {
//   //private ILogger<FakeController<TModel, TDto>> _logger;
//   private readonly ICURDServiceCOPY<TModel, TDto> _service;
//   public FakeController(ICURDServiceCOPY<TModel, TDto> service)
//   {
//     _service = service;
//    // _logger = logger;
//   }

//   [HttpGet]
//   public async Task<ActionResult<ICollection<TModel>>> GetAll()
//   {
//     if (_service.GetAll() is null)
//     {
//       return NotFound("No data to be returned");
//     }
//     return Ok(_service.GetAll());
//   }

//   [HttpPost]
//   public async Task<IActionResult> Create(TDto item)
//   {
//     //Console.WriteLine("creating new item..");
//     //_logger.LogInformation("Creating New Student");
//     await _service.Create(item);
//     return Ok();
//   }

//   [HttpGet("{id}")]
//   public async Task<ActionResult<TModel?>> Get(int id)
//   {
//     var data = await _service.Get(id);
//     if (data is null)
//     {
//       return NotFound("Item is not found");
//     }
//     return data;
//   }

//   [HttpPut("{id}")]
//   public  async Task<ActionResult> Update(int id, TDto item)
//   {
//     var c = await _service.Update(id, item);
//     if (c is null)
//     {
//       return NotFound("Item is not found");
//     }
//     return Ok(c);
//   }

//   [HttpDelete("{id:int}")]
//   public async Task<ActionResult> Delete(int id)
//   {
//     if (await _service.Delete(id))
//     {
//       return Ok("Item Deleted successfully");
//     }
//     return NotFound("Item could not be deleted");
//   }
// }