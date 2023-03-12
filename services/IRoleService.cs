namespace project.services;

using Microsoft.AspNetCore.Identity;
using project.DTOs;

public interface IRoleService
{
    Task<IEnumerable<string>> AddRolesAsync(ICollection<string> names);
    Task<List<IdentityRole<Guid>>> GetRolesAsync();

    // Task<bool> RemoveRolesAsync(ICollection<string> names);
    // Task<bool> AssignRoleToUserAsync(DTORole role);
    // Task<bool> UnAssignRoleToUserAsync();
}