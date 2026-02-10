namespace NetEnterprise.Application.DTOs.Company;

public class CreateCompanyDto
{
    public string BusinessName { get; set; } = null!;
    public string? Street { get; set; }
    public string? ExteriorNumber { get; set; }
    public string? InteriorNumber { get; set; }
    public string? Neighborhood { get; set; }
    public string? Locality { get; set; }
    public string? Municipality { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public string? TaxId { get; set; }
    public string? PrimaryPhone { get; set; }
    public string? SecondaryPhone { get; set; }
    public string? ErpSystemCode { get; set; }
    public int? IndustryTypeId { get; set; }
    public string? CompanyTitle { get; set; }
}