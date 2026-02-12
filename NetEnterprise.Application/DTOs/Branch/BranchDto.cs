namespace NetEnterprise.Application.DTOs.Branch;

public class BranchDto
{
    public int BranchId { get; set; }
    public Guid BranchUid { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string? CommercialName { get; set; }
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string AddressSuburb { get; set; } = null!;
    public string AddressCity { get; set; } = null!;
    public string AddressMunicipality { get; set; } = null!;
    public string AddressState { get; set; } = null!;
    public string AddressPostalCode { get; set; } = null!;
    public string AddressCountry { get; set; } = null!;
    public string TaxIdentificationNumber { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? SecondaryPhoneNumber { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string? Website { get; set; }
    public bool Active { get; set; }
}