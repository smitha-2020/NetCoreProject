namespace project.Controllers;


using Microsoft.AspNetCore.Mvc;
using project.services;
using project.Models;
using project.DTOs;


public class FakeProductController : FakeController<Product, DTOProduct>
{
  private readonly IProductService _service;

  public FakeProductController(IProductService service) : base(service)
  {
    _service = service;
  }

  [HttpGet("byorder")]
  public async Task<ActionResult<Product>> GetByOrder()
  {
    var orderbycost = await _service.GetAllProductsByCostAsc();
    if (orderbycost is null)
    {
      return BadRequest("Nothing to sort");
    }
    return Ok(orderbycost);
  }
}