using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using project.services;

namespace project.Controllers;

public class RoleController : ApiController
{
    private readonly IRoleService _service;
    private readonly ILogger<RoleController> _logger;

    public RoleController(IRoleService service,ILogger<RoleController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody]ICollection<string> names)
    {
        var result = await _service.AddRolesAsync(names);
        _logger.LogCritical(result.ToString());
        if (result.Count() > 0)
        {
            return Ok($"Added {result.Count()} roles to the database.");
        }
        return BadRequest();
    }

     [HttpGet]
    public async Task<ActionResult<IList<IdentityRole<Guid>>>> GetRoles()
    {
        return await _service.GetRolesAsync();
    }
}