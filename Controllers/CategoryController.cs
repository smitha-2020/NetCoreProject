using Microsoft.AspNetCore.Mvc;
using project.DTOs;
using project.Models;
using project.services;

namespace project.Controllers;

public class CategoryController : DbCURDController<Category, DTOCategory>
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service) : base(service)
    {
        _service = service;
    }
}