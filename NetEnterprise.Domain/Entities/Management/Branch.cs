using NetEnterprise.Domain.Common;

namespace NetEnterprise.Domain.Entities.Management;

public class Branch : AuditableEntity
{
    public int BranchId { get; set; }
    public Guid BranchUid { get; set; }
    public int CompanyId { get; set; }

    // Branch Information
    public string Name { get; set; } = string.Empty;

    public string? CommercialName { get; set; }
    public int? BranchTypeId { get; set; }

    // Physical Address
    public string AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; }
    public string AddressSuburb { get; set; } = string.Empty;
    public string AddressCity { get; set; } = string.Empty;
    public string AddressMunicipality { get; set; } = string.Empty;
    public string AddressState { get; set; } = string.Empty;
    public string AddressPostalCode { get; set; } = string.Empty;
    public string AddressCountry { get; set; } = "México";

    // Contact Information
    public string TaxIdentificationNumber { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    public string? SecondaryPhoneNumber { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public string? Website { get; set; }

    // Navigation properties
    public Company Company { get; set; } = null!;
}