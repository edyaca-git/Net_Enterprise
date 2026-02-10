using NetEnterprise.Domain.Common;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Domain.Entities.Security;

public class Role : AuditableEntity
{
    public int RoleId { get; set; }
    public int BranchId { get; set; }
    public string RoleCode { get; set; } = null!;
    public string Description { get; set; } = null!;

    // Navigation properties
    public Branch Branch { get; set; } = null!;

    public ICollection<User> Users { get; set; } = new List<User>();
}