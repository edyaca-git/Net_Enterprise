using NetEnterprise.Domain.Common;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Domain.Entities.Catalog;

public class Group : AuditableEntity
{
    public int GroupId { get; set; }
    public int BranchId { get; set; }
    public string Name { get; set; } = null!;

    // Navigation properties
    public Branch Branch { get; set; } = null!;

    public ICollection<SubGroup> SubGroups { get; set; } = new List<SubGroup>();
}