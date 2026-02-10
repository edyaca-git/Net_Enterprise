namespace NetEnterprise.Application.DTOs.User;

public class UserRegisteredResponse
{
    public int UserId { get; set; }
    public string UserAccount { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
}