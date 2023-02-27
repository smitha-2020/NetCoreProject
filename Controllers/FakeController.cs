namespace project.Controllers;

using Microsoft.AspNetCore.Mvc;

using project.services;
using project.Models;
using project.DTOs;

public abstract class FakeController<TModel, TDto> : ApiController
where TModel : BaseModel, new()
where TDto : BaseDTO<TModel>
{
  private readonly ICURDServiceCOPY<TModel, TDto> _service;
  public FakeController(ICURDServiceCOPY<TModel, TDto> service)
  {
    _service = service;
  }

  // [HttpPost]
  // public ActionResult<TModel> Create(TDto product)
  // {
  //   var data = _service.Create(product);
  //   if (data is null)
  //   {
  //     return NotFound("Coould not be created!!!");
  //   }
  //   return Ok(data);
  // }

  [HttpGet]
  public ActionResult<ICollection<TModel>> GetAll()
  {
    if (_service.GetAll() is null)
    {
      return NotFound("No data to be returned");
    }
    return Ok(_service.GetAll());
  }
}