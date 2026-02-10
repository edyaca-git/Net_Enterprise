using NetEnterprise.Domain.Common;
using NetEnterprise.Domain.Entities.Global;

namespace NetEnterprise.Domain.Entities.Management;

public class Company : AuditableEntity
{
    public int CompanyId { get; set; }
    public Guid CompanyUid { get; set; }
    public string BusinessName { get; set; } = null!;

    // Address
    public string? Street { get; set; }

    public string? ExteriorNumber { get; set; }
    public string? InteriorNumber { get; set; }
    public string? Neighborhood { get; set; }
    public string? Locality { get; set; }
    public string? Municipality { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }

    // Fiscal & Contact
    public string? TaxId { get; set; }

    public string? PrimaryPhone { get; set; }
    public string? SecondaryPhone { get; set; }

    // System info
    public string? ErpSystemCode { get; set; }

    public int? IndustryTypeId { get; set; }
    public string? CompanyTitle { get; set; }
    public int? LegacyRecordId { get; set; }

    // Navigation properties
    public IndustryType? IndustryType { get; set; }

    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
}