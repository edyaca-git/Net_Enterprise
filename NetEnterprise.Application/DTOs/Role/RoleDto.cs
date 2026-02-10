namespace NetEnterprise.Application.DTOs.Role;

public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Active { get; set; }
}