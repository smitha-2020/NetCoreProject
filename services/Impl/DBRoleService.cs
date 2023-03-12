using Microsoft.AspNetCore.Identity;
using project.DTOs;
using project.Models;

namespace project.services;

public class DBRoleService : IRoleService
{
  private readonly RoleManager<IdentityRole<Guid>> _roleManager;
  private readonly UserManager<User> _userManager;

  public DBRoleService(RoleManager<IdentityRole<Guid>> roleManager, UserManager<User> userManager)
  {
    _roleManager = roleManager;
    _userManager = userManager;
  }

  //IdentityRole<Guid> is the table with Guid as id
  public async Task<IEnumerable<string>> AddRolesAsync(ICollection<string> names)
  {
    List<string> addedRoles = new List<string>();
    foreach (var name in names)
    {
      var result = await _roleManager.FindByNameAsync(name);
      if (result is null)
      {
        var role = await _roleManager.CreateAsync(new IdentityRole<Guid> { Name = name });
        if (role.Succeeded)
        {
          addedRoles.Add(name);
        }
      }
    }
    return addedRoles;
  }

  public Task<List<IdentityRole<Guid>>> GetRolesAsync()
  {
    return Task.Run(()=> _roleManager.Roles.ToList());
  }

  // public async Task<bool> AssignRoleToUserAsync(DTORole role)
  // {
  //   //check if the user exists
  //   var user = await _userManager.FindByEmailAsync(role.Email);
  //   if (user is null)
  //   {
  //     return false;
  //   }
  //   //check if the role exists
  //   var userRole = _roleManager.FindByNameAsync(role.RoleName);
  //   if (userRole is null)
  //   {
  //     return false;
  //   }
  //   //add role to user
  //   var assignedUser = await _userManager.AddToRoleAsync(user, role.RoleName);
  //   if (!assignedUser.Succeeded)
  //   {
  //     return false;
  //   }
  //   return true;
  // }

  // public async Task<bool> RemoveRolesAsync(ICollection<string> names)
  // {
  //   var count = names.Count();
  //   var i = 0;
  //   foreach (var name in names)
  //   {
  //     if (!(await _roleManager.FindByNameAsync(name) is null))
  //     {
  //       await _roleManager.DeleteAsync(new IdentityRole<Guid> { Name = name });
  //     }
  //   }
  //   if (i == 0)
  //   {
  //     return false;
  //   }
  //   return true;
  // }

  // public Task<bool> UnAssignRoleToUserAsync()
  // {
  //   throw new NotImplementedException();
  // }
}