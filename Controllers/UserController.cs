using Microsoft.AspNetCore.Mvc;
using project.DTOs;
using project.Models;
using project.services;
using project.AutoMapper;

namespace project.Controllers;

public class UserController : ApiController
{
    private readonly IUserservice _service;

    public UserController(IUserservice service) => _service = service;
    
    [HttpPost("/signup")]
    public async Task<IActionResult?> SingnUp([FromBody]DTOUserSignUp request)
    {
        var user = await _service.SingnUpAsync(request);
        if(user is null){
            return BadRequest();
        }
        return Ok(user.UserMapper());
    }
}