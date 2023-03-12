using project.DTOs;
using project.Models;

namespace project.AutoMapper;

public static class UserExtension
{
  public static DTOUserResponse UserMapper(this User user)
  {
    return new DTOUserResponse
    {
      FirstName = user.FirstName,
      LastName = user.LastName,
      Username = user.Email,
      Email = user.Email
    };
  }
}