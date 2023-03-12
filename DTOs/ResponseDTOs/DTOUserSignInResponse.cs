namespace project.DTOs;

public class DTOUserSignInResponse
{
    public string AccessToken { get; set; } = null!;
    public DateTime ExpirationTime { get; set; }
}