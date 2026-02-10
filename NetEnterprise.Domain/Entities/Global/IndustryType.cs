using NetEnterprise.Domain.Common;
using NetEnterprise.Domain.Entities.Management;

namespace NetEnterprise.Domain.Entities.Global;

public class IndustryType : AuditableEntity
{
    public int IndustryTypeId { get; set; }
    public string IndustryCode { get; set; } = null!;
    public string Description { get; set; } = null!;
}