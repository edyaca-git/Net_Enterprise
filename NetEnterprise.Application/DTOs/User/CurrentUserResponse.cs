namespace NetEnterprise.Application.DTOs.User;

public class CurrentUserResponse
{
    public int UserId { get; set; }
    public string UserAccount { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string RoleDescription { get; set; } = null!;
    public string CountryCode { get; set; } = null!;
    public string CountryName { get; set; } = null!;
    public int BranchId { get; set; }
}