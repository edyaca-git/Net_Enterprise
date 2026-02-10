namespace NetEnterprise.Application.DTOs.Country;

public class CountryDto
{
    public int CountryId { get; set; }
    public string CountryCode { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? UTCdiff { get; set; }
    public int? LanguageId { get; set; }
    public bool Active { get; set; }
}