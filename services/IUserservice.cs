namespace project.services;

using project.DTOs;
using project.Models;

public interface IUserservice
{
    Task<User?> SingnUpAsync(DTOUserSignUp request);
    Task<DTOUserSignInResponse?> SingnInAsync(DTOUserSignIn request);
}