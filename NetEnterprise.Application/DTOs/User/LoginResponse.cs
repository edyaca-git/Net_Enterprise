namespace NetEnterprise.Application.DTOs.User;

public class LoginResponse
{
    public string Token { get; set; } = null!;
    public int UserId { get; set; }
    public string UserAccount { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Role { get; set; } = null!;
    public int BranchId { get; set; }
}