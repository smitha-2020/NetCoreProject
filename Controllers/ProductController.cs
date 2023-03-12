using Microsoft.AspNetCore.Mvc;
using project.DTOs;
using project.Models;
using project.services;
using project.AutoMapper;

namespace project.Controllers;

public class ProductController : DbCURDController<Product, DTOProduct>
{
  private readonly IProductService _service;
  private readonly ILogger<ProductController> _logger;
  public ProductController(IProductService service, ILogger<ProductController> logger) : base(service)
  {
    _service = service;
    _logger = logger;
  }

  [HttpGet]
  public override async Task<ICollection<Product>?> GetAll()
  {
    ICollection<Product> _products = new List<Product>();
    var products = await _service.GetAllAsync();
    if (products is null)
    {
      return null;
    }
    foreach (var product in products)
    {
      _products.Add(Product.ConvertToDTO(product));
    }
    return _products;
  }

  [HttpGet("{id}")]
  public override async Task<ActionResult<Product?>> Get(int id)
  {
    var product = await _service.GetAsync(id);
    if (product is null)
    {
      return NotFound("Item is not found");
    }
    return Product.ConvertToDTO(product);
  }

  [HttpGet("search")]
  public async Task<ActionResult<Product?>> GetBySearch(FilterDTO request)
  {
    var products = await GetAll();
    if (products is null)
    {
      return BadRequest();
    }
    if (!string.IsNullOrEmpty(request.Search))
    {
      products = (ICollection<Product>)products.Where(x => x.Title.Contains(request.Search));
    }
    else if (request.DisplayOrder == Order.asc)
    {
      products = products.OrderBy(x => x.Title).ToList();
    }
    else if (request.CostOrder == Order.asc)
    {
      products = products.OrderBy(x => x.Price).ToList();
    }
    products.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();
    return Ok(products);
  }
  public enum Order
  {
    asc,
    desc
  }
  public class FilterDTO
  {
    public string? Search { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
    public Order? DisplayOrder { get; set; }
    public Order? CostOrder { get; set; }
  }
}