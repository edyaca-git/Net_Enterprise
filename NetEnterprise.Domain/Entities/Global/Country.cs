using NetEnterprise.Domain.Common;
using NetEnterprise.Domain.Entities.Management;
using NetEnterprise.Domain.Entities.Security;

namespace NetEnterprise.Domain.Entities.Global;

public class Country : AuditableEntity
{
    public int CountryId { get; set; }
    public string CountryCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? UTCdiff { get; set; }
    public int? LanguageId { get; set; }
}